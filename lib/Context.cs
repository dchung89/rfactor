using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Compilers;
using Roslyn.Compilers.Common;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.Editor;

namespace Rfactor.Lib
{
    class Context
    {
        IWorkspace iWorkspace;
        ISolution iSolution;
        IDocument iDocument;

        ICompilation compilation;

        public Context(IWorkspace iwork, ISolution isol, IDocument idoc = null)
        {
            this.iWorkspace = iwork;
            this.iSolution = isol;
            this.iDocument = idoc;
            this.compilation = iSolution.Projects.First().GetCompilation();
        }

        public IWorkspace GetIWorkspace()
        {
            return this.iWorkspace;
        }

        public ISolution GetISolution()
        {
            return this.iSolution;
        }

        public IDocument getIDocument()
        {
            return this.iDocument;
        }

        /* ------------------------------------------------------ */
        //    Helper functions
        /* ------------------------------------------------------ */

        // Summary:
        //     Returns the results of a recursive search for members
        //     that can be referenced from source-code 
        //     throughout the entire project, including references. 
        // 
        //     Note: See GetAssemblySymbolTable() for only the symbols
        //           contained within the source-code. 
        //
        protected IEnumerable<Symbol> GetFullSymbolTable()
        {
            NamespaceSymbol globalNamespace = (NamespaceSymbol)compilation.GlobalNamespace;

            List<Symbol> list = new List<Symbol>();
            RecursiveStep(list, globalNamespace);

            return list;
        }


        // Summary:
        //     Returns the results of a recursive search for members
        //     that can be referenced from source-code 
        //     throughout the local project. This does NOT include references. 
        // 
        //     Note: See GetFullSymbolTable() for a full listing of symbols. 
        //
        protected IEnumerable<Symbol> GetAssemblySymbolTable()
        {
            NamespaceSymbol globalNamespace = (NamespaceSymbol)compilation.Assembly.GlobalNamespace;

            List<Symbol> list = new List<Symbol>();
            RecursiveStep(list, globalNamespace);

            return list;
        }

        // 
        private void RecursiveStep(List<Symbol> agg, NamespaceSymbol namespaceSymbol)
        {
            foreach (var mem in namespaceSymbol.GetMembers())
                agg.Add(mem);
            foreach (var mem in namespaceSymbol.GetTypeMembers())
            {
                RecursiveStep(agg,mem);
            }
            foreach (var mem in namespaceSymbol.GetNamespaceMembers())
            {
                RecursiveStep(agg, mem);
            }
        }

        // 
        private void RecursiveStep(List<Symbol> agg, NamedTypeSymbol typeSymbol)
        {

            // Add all low-level members to the list
            foreach (var mem in typeSymbol.GetMembers())
                agg.Add(mem);

            // Step into nested types
            foreach (var mem in typeSymbol.GetTypeMembers())
            {
                RecursiveStep(agg, mem);
            }

            /*foreach (MethodSymbol mem in typeSymbol.GetMembers().Where((val) =>
                {
                    return val.Kind == SymbolKind.Method;
                }))
            {
                var tree = mem.Locations.Single().SourceTree;
                SemanticModel sem = (SemanticModel)compilation.GetSemanticModel(tree);
                foreach (var node in tree.Root.DescendentNodes().OfType<LocalDeclarationStatementSyntax>())
                {
                    sem.LookupSymbols(
                    agg.Add(bla);
                }
            }*/

        }


        // Summary:
        //     This method takes two symbols sym and scope, and starting
        //     from sym, works its way outwards comparing containing symbols. 
        //     If any symbols along the way 
        //     are equal to scope, the method returns true. Else: false.
        //
        private bool CheckScopesOutward(Symbol sym, Symbol scope)
        {
            if (sym == null)
                return false; // no matching symbol found

            if (sym == scope)
                return true; // match found
            else
                return CheckScopesOutward(sym.ContainingSymbol, scope);
        }


        /* ---------------------------------------------------------------- */
        /* ------------------Section 4.3.3--------------------------------- */
        /* ---------------------------------------------------------------- */

        // Author: Casper
        // Summary: Checks to see whether creating a new source-referencable 
        //          symbol with a given name would conflict with a pre-
        //          existing one. 
        //              true: there was a collision
        //             false: there wasn't a collision
        // Opdyke (4.3.3-7)
        //
        // Future Work: Verify that a symbol in a parent scope actually
        //              propagates down (protected, public)
        //     
        public bool varNameCollisionP(string S, Symbol scope)
        {
            IEnumerable<Symbol> list = GetAssemblySymbolTable();
            
            // Check the entire symbol table for a potential collision
            list = list.Where((val) =>
                {
                    return val.Name == S;
                });
            if (list.Count() == 0)
                return false; // entire symbol table contains no collisions

            // Check the potential collisions for similar scope
            list = list.Where((val) =>
                {
                    if (CheckScopesOutward(val, scope))
                    {
                        // Check if this is the original def.
                        // Assumption: definitions are not inherited
                        if (val.IsDefinition)
                            return true;

                        // Check if the original definition is private
                        if (val.OriginalDefinition.DeclaredAccessibility == Roslyn.Compilers.CSharp.Accessibility.Private)
                            return false;

                        // Else, assume conflict
                        return true;
                    }
                    return false;
                });

            if (list.Count() > 0)
                return true;
            return false;
        }


        /* ---------------------------------------------------------------- */
        /* -------------------Section 4.3.4-------------------------------- */
        /* ---------------------------------------------------------------- */

        // Author: Casper
        // Summary: Returns a list of all of the declared functions
        // Opdyke (4.3.4-1)
        // 
        public IEnumerable<Symbol> allFunctions()
        {
            IEnumerable<Symbol> list = GetAssemblySymbolTable();
            return list.Where((sym) =>
                {
                    return sym.Kind == SymbolKind.Method;
                });
        }

        // Author: Casper
        // Summary: Returns a list of all of the declared variables
        // Opdyke (4.3.4-2)
        // 
        public IEnumerable<Symbol> allVariables()
        {
            IEnumerable<Symbol> list = GetAssemblySymbolTable();
            return list.Where((sym) =>
                {
                    //bool flag = false;
                    //flag = flag || sym.Kind == SymbolKind.Local;
                    //flag = flag || sym.Kind == SymbolKind.Field;
                    //flag = flag || sym.Kind == SymbolKind.Property;
                    return true; 
                });
        }

        // Author: Casper
        // Summary: Returns a list of all of the declared Classes
        // 
        public IEnumerable<Symbol> allTypes()
        {
            IEnumerable<Symbol> list = GetAssemblySymbolTable();
            return list.Where((sym) =>
                {
                    bool flag = false;
                    flag = flag || sym.Kind == SymbolKind.NamedType;
                    flag = flag || sym.Kind == SymbolKind.DynamicType;
                    // There are other types, maybe they should be included.
                    return flag;
                });
        }

        
    }
}
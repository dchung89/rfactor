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
            {
                if (mem.CanBeReferencedByName)
                    agg.Add(mem);
            }
            // Step into nested types
            foreach (var mem in typeSymbol.GetTypeMembers())
            {
                RecursiveStep(agg, mem);
            }
        }


        /* ------------------------------------*/
        /* Opdyke Stuff */
        /* ------------------------------------*/

        // Author: Casper
        // Summary: Returns a list of all of the declared functions
        // Opdyke (4.3.4-1)
        // 
        public IEnumerable<Symbol> allFunctions()
        {
            IEnumerable<Symbol> list = GetFullSymbolTable();
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
            IEnumerable<Symbol> list = GetFullSymbolTable();
            return list.Where((sym) =>
                {
                    bool flag = false;
                    flag = flag || sym.Kind == SymbolKind.Field;
                    flag = flag || sym.Kind == SymbolKind.Property;
                    return flag;
                });
        }
    }
}
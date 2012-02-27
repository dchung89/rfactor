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

        protected IEnumerable<Symbol> GetFullSymbolTable()
        {
            NamespaceSymbol globalNamespace = (NamespaceSymbol)compilation.Assembly.GlobalNamespace;

            List<Symbol> list = new List<Symbol>();
            RecursiveStep(list, globalNamespace);

            return list;
        }

        protected void RecursiveStep(List<Symbol> agg, NamespaceSymbol namespaceSymbol)
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

        protected void RecursiveStep(List<Symbol> agg, NamedTypeSymbol typeSymbol)
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

        // 4.3.4-1 (Casper)
        public IEnumerable<Symbol> allFunctions()
        {
            IEnumerable<Symbol> list = GetFullSymbolTable();
            return list.Where((sym) =>
                {
                    if (sym.Kind == SymbolKind.Method)
                        return true;
                    return false;
                });
        }
    }
}
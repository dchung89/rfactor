using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Compilers;
using Roslyn.Compilers.Common;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.Editor;

namespace Rfactor.Lib.Preconditions
{
    class InheritedNameConflict : IPrecondition
    {
        String name;
        SemanticModel sem;
        CommonSyntaxNodeOrToken selected;

        public IPreconditionResult Check()
        {
            return CheckForInheritedNameConflict();
        }

        public InheritedNameConflict(String name, CommonSyntaxNodeOrToken selected, IDocument doc)
        {
            this.name = name;
            this.selected = selected;
            this.sem = (SemanticModel)doc.GetSemanticModel();
        }

        private IPreconditionResult CheckForInheritedNameConflict()
        {
            IEnumerable<Symbol> syms = this.sem.LookupSymbols(selected.Span.Start);
            syms = syms.Where((sym) =>
                {
                    return sym.Name == name;
                });

            Symbol selected_sym = sem.GetDeclaredSymbol((SyntaxNode)selected);

            // Where is the symbol definition?
            foreach (Symbol s in syms)
            {
                // Note: This might not allow for different methods to have same names. 
                if (s.OriginalDefinition.ContainingSymbol == selected_sym.ContainingSymbol)
                {
                    return new GenericResult(Result.LocalConflict);
                }
                else
                {
                    return new GenericResult(Result.InheritedConflict);
                }
            }
            return new GenericResult(Result.Success);
        }
    }
}

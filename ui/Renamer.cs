using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using System.Diagnostics.CodeAnalysis;

namespace rfactor
{

    // Example Usage: 
    //   var tree = SyntaxTree.ParseCompilationUnit(text);
    //   Renamer r = new Renamer("myVar","newVar");
    //   tree = r.Visit(tree.Root);
    //   new_text = tree.ToString();
    [ExcludeFromCodeCoverage]
    class Renamer : SyntaxRewriter
    {
        string oldName, newName;


        public Renamer(string oldName, string newName)
        {
            this.oldName = oldName;
            this.newName = newName;
        }

        protected override SyntaxToken VisitToken(SyntaxToken token)
        {
            if (token != null)
            {
                if (token.Kind == SyntaxKind.IdentifierToken && token.GetText() == this.oldName)
                    return Syntax.Identifier(token.LeadingTrivia,
                                                this.newName,
                                                token.TrailingTrivia);
            }
            return token;
        }
    }
}

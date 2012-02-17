using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;

namespace rfactor
{

    // Local Variable check only
    class RenamerChecker : SyntaxWalker
    {
        private bool conflict = false;
        private string newName = null;


        // Author: Casper & David
        // Summary: 
        //   Checks the AST passed through for any IdentifierTokens with name *newName*
        public bool checkFor(string newName,SyntaxNode tree)
        {
            this.newName = newName;
            Visit(tree);
            return false;
        }

        
        // ClassDeclaration/IdentifierToken
        protected override void VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            check(node); // do not descend
        }


        // MethodDeclaration/IdentifierToken
        protected override void VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            check(node); // do not descend
        }


        // VariableDeclarator/IdentifierToken
        protected override void VisitVariableDeclarator(VariableDeclaratorSyntax node)
        {
            check(node);
            base.VisitVariableDeclarator(node);
        }


        // NamespaceDeclaration/IdentiferName/IdentifierToken,
        // Expression.../IdentiferName/IdentifierToken
        protected override void VisitIdentifierName(IdentifierNameSyntax node)
        {
            check(node);
            base.VisitIdentifierName(node);
        }


        // Author: Casper & David
        // Summary: 
        //   
        private void check(SyntaxNode node)
        {
            if (getIdentifierTokenText(node) == this.newName)
                Console.WriteLine("Conflict: {0} {1} already exists", node.Kind.ToString(), newName);
                // throw new exception
        }


        // Author: Casper & David
        // Summary: 
        //   
        private string getIdentifierTokenText(SyntaxNode node)
        {
            return node.DescendentTokens().Where((token) =>
                {
                    if (token.Kind == SyntaxKind.IdentifierToken)
                        return true;
                    return false;
                }).First().GetText();
        }
        
    }
}

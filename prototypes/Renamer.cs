using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;

namespace rfactor
{

    class Renamer : SyntaxRewriter
    {
        string oldName, newName;
        
        
        public Renamer(string oldName, string newName)
        {
            this.oldName = oldName;
            this.newName = newName;
        }

        // ******************************************************************************
        // **************** Skip any nodes that change scope without a block node *******
        // ******************************************************************************
        // ** 
        // ** 
        protected override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
        {
            return node;
        }
        protected override SyntaxNode VisitNamespaceDeclaration(NamespaceDeclarationSyntax node)
        {
            return node;
        }
        // ******************************************************************************
        // **************** Skip any block nodes ****************************************
        // ******************************************************************************
        // ** 
        // ** 
        protected override SyntaxNode VisitBlock(BlockSyntax node)
        {
            return node;
        }

        protected override SyntaxToken VisitToken(SyntaxToken token)
        {
            if (token.Kind == SyntaxKind.IdentifierToken && token.GetText() == this.oldName)
                return Syntax.Identifier(token.LeadingTrivia,
                                            this.newName,
                                            token.TrailingTrivia);
            return token;
        }
    }
}

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
    class LocalNameConflict : IPrecondition
    {
        String name;
        SyntaxTree tree;
        CommonSyntaxNodeOrToken selected;

        public LocalNameConflict(String name, CommonSyntaxNodeOrToken selected, SyntaxTree tree)
        {
            this.name = name;
            this.selected = selected;
            this.tree = tree;
        }

        public IPreconditionResult Check()
        {
            return CheckForLocalNameConflict(this.name, this.tree);
        }

        public IPreconditionResult CheckForLocalNameConflict(String name, SyntaxTree tree)
        {
            // Find all tokens that might conflict in the file
            IEnumerable<SyntaxToken> list = GetAllTokensWithNameInTree(name, tree);
            // If the list is empty, there is no local conflict
            if (list.Count() == 0)
                return new LocalNameConflictResult(list);
            // If it isn't, run through the potential conflicts
            LocalNameConflictResult res = new LocalNameConflictResult();
            foreach (SyntaxToken token in list)
            {
                var parent = GetContainingNodeOfInterest(token);
                if (parent == GetContainingNodeOfInterest((SyntaxNodeOrToken)selected))
                    res.AddConflict(token);
            }
            return res;
        }

        public SyntaxNode GetContainingNodeOfInterest(SyntaxNodeOrToken nodeOrToken)
        {
            if (nodeOrToken.Kind == SyntaxKind.MethodDeclaration
                || nodeOrToken.Kind == SyntaxKind.ClassDeclaration
                || nodeOrToken == null)
                return (SyntaxNode)nodeOrToken;
            return GetContainingNodeOfInterest(nodeOrToken.Parent);
        }

        public IEnumerable<SyntaxToken> GetAllTokensWithNameInTree(String name, SyntaxTree tree)
        {
            IEnumerable<SyntaxToken> list = tree.Root.DescendentTokens().Where((token) =>
            {
                if (token.Kind == SyntaxKind.IdentifierToken)
                    if (token.GetText() == name)
                        return true;
                return false;
            });
            return list;
        }
    }
}

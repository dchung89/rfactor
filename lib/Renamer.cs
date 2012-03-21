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
    class Renamer
    {
        IDocument doc;
        TextSpan text;
        CommonSyntaxNodeOrToken selected;

        public Renamer(IDocument doc, TextSpan text)
        {
            this.doc = doc;
            this.text = text;
            this.selected = doc.GetSyntaxTree().Root.DescendentNodesAndTokensAndSelf(text).First();
        }

        /// <summary>
        /// Gets each location of the class symbol sym in the source
        /// </summary>
        /// <returns>An array of locations</returns>
        /*public ReadOnlyArray<Location> GetSymbolLocations()
        {
            return this.sym.Locations;
        }*/

        /// <summary>
        /// Gets each location of the given symbol sym in the source
        /// </summary>
        /// <param name="sym">Symbol to get locations for</param>
        /// <returns>An array of locations</returns>
        /*public ReadOnlyArray<Location> GetSymbolLocations(Symbol sym)
        {
            return sym.Locations;
        }*/

        /// <summary>
        /// Gets the syntax tree for the given location loc
        /// </summary>
        /// <param name="loc">A location</param>
        /// <returns>A syntax tree</returns>
        public SyntaxTree GetSyntaxTreeForLocation(Location loc)
        {
            return loc.SourceTree;
        }

        public void CheckPreconditions()
        {
            ReadOnlyArray<Location> locations = GetSymbolLocations();
            foreach (Location loc in locations)
            {
                
            }
        }

        public void CheckForLocalNameConflict(String name, SyntaxTree tree)
        {
            // Find all tokens that might conflict in the file
            IEnumerable<SyntaxToken> list = GetAllTokensWithNameInTree(name, tree);
            // If the list is empty, there is no local conflict
            if (list.Count() == 0)
                return;
            foreach (SyntaxToken token in list)
            {
                
            }
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

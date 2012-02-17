using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;

namespace rfactor
{
    [Obsolete("Use Renamer instead")]
    class Rename
    {
        public string oldRename(string original_string, string old_name, string new_name)
        {
            return SyntaxTokenRename(original_string, old_name, new_name);
            //return SearchAndReplaceRename(original_string, old_name, new_name);
        }

        private string SearchAndReplaceRename(string original_string, string old_name, string new_name)
        {
            string pat = "\\W"+old_name+"\\W";
            Regex rgx = new Regex(pat);

            return rgx.Replace(original_string, (match) =>
                {
                    return match.ToString().Replace(old_name, new_name);
                });
        }

        private string SyntaxTokenRename(string original_string, string old_name, string new_name)
        {
            SyntaxTree tree = SyntaxTree.ParseCompilationUnit(original_string);

            var tokens = tree.Root.DescendentTokens().OfType<SyntaxToken>().Where((token) =>
                {
                    if (token.Kind == SyntaxKind.IdentifierToken)
                        if (token.ValueText == old_name)
                            return true;
                    return false;
                });

            SyntaxTree tree2 = SyntaxTree.Create("t",(CompilationUnitSyntax)tree.Root.ReplaceTokens(tokens, (token, IGNORE) =>
                {
                    return token.CopyAnnotations(Syntax.Identifier(new_name));
                }));

            return tree2.ToString();
        }
    }
    
}

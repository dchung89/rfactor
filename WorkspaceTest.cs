using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using rfactor.lib.refactorings;
using Roslyn.Services;
using Roslyn.Services.Editor;

namespace rfactor
{
    [TestFixture]
    class WorkspaceTest
    {
        IWorkspace workspace;
        ISolution solution;
        IDocument document;
        IProject project;

        [Test]
        public void test()
        {
            // I added the SampleApp solution in the testingfiles folder
            workspace = Workspace.LoadSolution(@"../../testingfiles/SampleApplication.sln");
            solution = workspace.CurrentSolution;

            Assert.IsNotNull(solution);

            int numOfProj = 0;
            foreach (IProject project in solution.Projects)
            {
                this.project = project;
                numOfProj++;
            }

            Assert.AreEqual(numOfProj, 1);

            int numOfDoc = 0;
            foreach (IDocument document in this.project.Documents)
            {
                this.document = document;
                numOfDoc++;
            }

            Assert.AreEqual(numOfDoc, 3);

            // Get Program.cs
            DocumentId id = this.project.DocumentIds.ElementAt<DocumentId>(1);

            System.IO.File.WriteAllText(@"../../testingfiles/SampleApplication.txt", id.FileName);

            this.document = this.project.GetDocument(id);

            // Just using the old Rename to check
            {
                string message = "message";

                SyntaxTree tree = (SyntaxTree)this.document.GetSyntaxTree();

                Assert.NotNull(tree);

                var tokens = tree.Root.DescendentTokens().OfType<SyntaxToken>().Where((token) =>
                {
                    if (token.Kind == SyntaxKind.IdentifierToken)
                        if (token.ValueText == message)
                            return true;
                    return false;
                });

                SyntaxTree tree2 = SyntaxTree.Create("t", (CompilationUnitSyntax)tree.Root.ReplaceTokens(tokens, (token, IGNORE) =>
                {
                    return token.CopyAnnotations(Syntax.Identifier(message.ToUpper()));
                }));

                // Write the results to file
                System.IO.File.WriteAllText(@"../../testingfiles/Program.txt", tree2.ToString());
            }
            // End of Rename
        }
    }
}

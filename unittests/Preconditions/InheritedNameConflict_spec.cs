using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Roslyn.Compilers;
using Roslyn.Compilers.Common;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.Editor;
using Rfactor.Lib;
using Rfactor.UnitTests.Stubs;
using Rfactor.Lib.Preconditions;

namespace Rfactor.UnitTests
{

    [TestFixture]
    class InheritedNameConflictTest
    {
        InheritedNameConflict inc;
        IDocument document;

        [SetUp]
        public void InitializeWithSampleApp()
        {
            IWorkspace workspace = Workspace.LoadSolution(@"../../TestFiles/SampleApplication.sln");
            ISolution solution = workspace.CurrentSolution;
            document = solution.Projects.FirstOrDefault().Documents.FirstOrDefault();
        }

        [Test]
        public void TestConflictInClassBody()
        {
            var bla = document.GetSyntaxTree().Root.DescendentNodesAndTokens().Where((token) =>
            {
                return token.GetText() == "message";
            });
            inc = new InheritedNameConflict("message", bla.FirstOrDefault(), document);
            IPreconditionResult res = inc.Check();
            Assert.False(res.VerifySuccess());
        }

        [Test]
        public void TestConflictInMethodBody()
        {
            var bla = document.GetSyntaxTree().Root.DescendentNodesAndTokens().Where((token) =>
            {
                return token.GetText() == "Message234";
            });
            inc = new InheritedNameConflict("Message234", bla.FirstOrDefault(), document);
            IPreconditionResult res = inc.Check();
            Assert.False(res.VerifySuccess());
        }

        [Test]
        public void TestSuccessInMethodBody()
        {
            var bla = document.GetSyntaxTree().Root.DescendentNodesAndTokens().Where((token) =>
            {
                return token.GetText() == "Message234";
            });
            inc = new InheritedNameConflict("Message23456", bla.FirstOrDefault(), document);
            IPreconditionResult res = inc.Check();
            Assert.True(res.VerifySuccess());
        }

        [Test]
        public void TestSuccessInClassBody()
        {
            var bla = document.GetSyntaxTree().Root.DescendentNodesAndTokens().Where((token) =>
            {
                return token.GetText() == "message";
            });
            inc = new InheritedNameConflict("idontexist", bla.FirstOrDefault(), document);
            IPreconditionResult res = inc.Check();
            Assert.True(res.VerifySuccess());
        }

        [Test]
        public void TestSuccessWithInheritedMember()
        {
            var bla = document.GetSyntaxTree().Root.DescendentNodesAndTokens().Where((token) =>
            {
                return token.GetText() == "bsdf";
            });
            inc = new InheritedNameConflict("csdf", bla.FirstOrDefault(), document);
            IPreconditionResult res = inc.Check();
            Assert.True(res.VerifySuccess());
        }

        [Test]
        public void TestConflictWithInheritedMember()
        {
            var bla = document.GetSyntaxTree().Root.DescendentNodesAndTokens().Where((token) =>
            {
                return token.GetText() == "bsdf";
            });
            inc = new InheritedNameConflict("asdf", bla.FirstOrDefault(), document);
            IPreconditionResult res = inc.Check();
            Assert.False(res.VerifySuccess());
        }
    }

}

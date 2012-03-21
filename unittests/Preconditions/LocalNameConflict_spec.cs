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
    class LocalNameConflictTest
    {
        LocalNameConflict lnc;
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
            lnc = new LocalNameConflict("message", bla.FirstOrDefault(), (SyntaxTree)document.GetSyntaxTree());
            IPreconditionResult res = lnc.Check();
            Assert.False(res.VerifySuccess());
        }

        [Test]
        public void TestConflictInMethodBody()
        {
            var bla = document.GetSyntaxTree().Root.DescendentNodesAndTokens().Where((token) =>
            {
                return token.GetText() == "Message234";
            });
            lnc = new LocalNameConflict("Message234", bla.FirstOrDefault(), (SyntaxTree)document.GetSyntaxTree());
            IPreconditionResult res = lnc.Check();
            Assert.False(res.VerifySuccess());
        }

        [Test]
        public void TestSuccessInMethodBody()
        {
            var bla = document.GetSyntaxTree().Root.DescendentNodesAndTokens().Where((token) =>
            {
                return token.GetText() == "Message234";
            });
            lnc = new LocalNameConflict("Message23456", bla.FirstOrDefault(), (SyntaxTree)document.GetSyntaxTree());
            IPreconditionResult res = lnc.Check();
            Assert.True(res.VerifySuccess());
        }

        [Test]
        public void TestSuccessInClassBody()
        {
            var bla = document.GetSyntaxTree().Root.DescendentNodesAndTokens().Where((token) =>
            {
                return token.GetText() == "message";
            });
            lnc = new LocalNameConflict("idontexist", bla.FirstOrDefault(), (SyntaxTree)document.GetSyntaxTree());
            IPreconditionResult res = lnc.Check();
            Assert.True(res.VerifySuccess());
        }

    }

}

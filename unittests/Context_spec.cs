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

namespace Rfactor.UnitTests
{

    [TestFixture]
    class ContextFactoryTest
    {

        Context ctx;

        [SetUp]
        public void InitializeWithSampleApp()
        {
            IWorkspace workspace = Workspace.LoadSolution(@"../../TestFiles/SampleApplication.sln");
            ISolution solution = workspace.CurrentSolution;
            ctx = new Context(workspace, solution);
        }

        /*[Test]
        public void InitializeWithStubs()
        {
            IWorkspaceStub iworkstub = null;
            ISolutionStub isolstub = null;
            IDocumentStub idocstub = null;
            try
            {
                iworkstub = new IWorkspaceStub();
                isolstub = new ISolutionStub();
                idocstub = new IDocumentStub();
            }
            catch (NotImplementedException e)
            {
            }

            ctx = new Context(iworkstub, isolstub, idocstub);
        }*/

        [Test]
        public void VerifyInitialization()
        {
            Assert.IsInstanceOf<Context>(ctx);
            Assert.NotNull(ctx);
        }

        [Test]
        public void TestGetIWorkspace()
        {
            var ws = ctx.GetIWorkspace();
            Assert.IsInstanceOf<IWorkspace>(ws);
            Assert.NotNull(ws);
        }

        [Test]
        public void TestGetISolution()
        {
            var isol = ctx.GetISolution();
            Assert.IsInstanceOf<ISolution>(isol);
            Assert.NotNull(isol);
        }

        [Test]
        public void TestGetNullIDocument()
        {
            var idoc = ctx.getIDocument();
            Assert.Null(idoc);
        }

        [Test]
        public void TestAllFunctions()
        {
            var a = ctx.allFunctions();
        }
    }

}

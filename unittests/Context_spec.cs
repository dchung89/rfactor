using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.Editor;
using rfactor.lib;
using rfactor.unittests.stubs;

namespace rfactor.unittests
{

    [TestFixture]
    class ContextFactoryTest
    {

        Context ctrlr;

        [SetUp]
        public void InitializeWithStubs()
        {
            IWorkspaceStub iworkstub = null;
            ISolutionStub isolstub = null;
            try
            {
                iworkstub = new IWorkspaceStub();
                isolstub = new ISolutionStub();
            }
            catch (NotImplementedException e)
            {
            }

            ctrlr = new Context(iworkstub, isolstub);
        }

        [Test]
        public void TestGetIWorkspace()
        {
            var ws = ctrlr.GetIWorkspace();
            Assert.IsInstanceOf<IWorkspace>(ws);
        }

        [Test]
        public void TestGetISolution()
        {
            var isol = ctrlr.GetISolution();
            Assert.IsInstanceOf<ISolution>(isol);
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.Editor;
using Rfactor.Lib;
using Rfactor.UnitTests.Stubs;

namespace Rfactor.UnitTests
{

    [TestFixture]
    class RfactorControllerTest
    {
        RfactorController ctrlr;

        [SetUp]
        public void TestInitializationWithStubs()
        {
            IWorkspaceStub iworkstub = null;
            ISolutionStub isolstub = null;
            

            ctrlr = new RfactorController(iworkstub,isolstub);
        }

        [Test]
        public void VerifyInitialization()
        {
            //Assert.IsInstanceOf<RfactorController>(ctrlr);
            //Assert.NotNull(ctrlr);
        }
    }

}

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
    class RfactorControllerTest
    {

        [Test]
        public void TestInitializationWithStubs()
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

            RfactorController ctrlr = new RfactorController(iworkstub,isolstub);
        }
    
    }

}

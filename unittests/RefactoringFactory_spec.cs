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
using rfactor.lib.refactorings;
using rfactor.unittests.stubs;

namespace rfactor.unittests
{

    [TestFixture]
    class RefactoringFactoryTest
    {

        RefactoringFactory refactoringFactory;

        [SetUp]
        public void InitializeWithStubs()
        {
            IWorkspaceStub iworkstub = null;
            ISolutionStub isolstub = null;
            Context ctx = null;
            try
            {
                iworkstub = new IWorkspaceStub();
                isolstub = new ISolutionStub();
                ctx = new Context(iworkstub, isolstub);
            }
            catch (NotImplementedException e)
            {
            }

            refactoringFactory = new RefactoringFactory(ctx);
        }

        [Test]
        public void VerifyInitialization()
        {
            Assert.IsInstanceOf<RefactoringFactory>(refactoringFactory);
            Assert.NotNull(refactoringFactory);
        }

        [Test]
        public void TestGetRenameLocalVariable()
        {
            var R = refactoringFactory.GetRenameLocalVariable(null, "NewName");
            Assert.IsInstanceOf<rename_local_variable>(R);
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Rfactor.Lib.Refactorings;

namespace Rfactor.UnitTests.refactorings
{
    [TestFixture]
    class rename_local_variable_spec
    {
        [SetUp]
        public void GetContext()
        {
            // get context here
        }

        [Test]
        public void BasicRename_01()
        {
            Assert.Ignore();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using rfactor.lib.refactorings;

namespace rfactor.unittests.refactorings
{
    [TestFixture]
    class create_empty_class_spec
    {
        [Test]
        public void check_preconditions()
        {
            Assert.Fail();
        }

        [Test]
        public void create_empty_class_test()
        {
            var t = create_empty_class.Create("MyNewClass");
        }

        [Test]
        public void create_empty_class_with_super()
        {
            var t = create_empty_class.Create("MyNewClass","SuperClass");
        }
    }
}

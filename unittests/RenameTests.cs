using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;

namespace rfactor.unittests
{

    [TestFixture]
    class RenameTests
    {

        [Test]
        public void Test1()
        {
            var tree = SyntaxTree.ParseCompilationUnit(@"var myVar;");
            Renamer r = new Renamer("myVar", "newVar");
            var newTree = r.Visit(tree.Root);
            Assert.AreEqual(@"var newVar;", newTree.ToString());
        }
        
        [Test]
        public void Test2()
        {
            var tree = SyntaxTree.ParseCompilationUnit(@"var myVar = ""Hello World"";");
            Renamer r = new Renamer("myVar", "newVar");
            var newTree = r.Visit(tree.Root);
            Assert.AreEqual(@"var newVar = ""Hello World"";", newTree.ToString());
        }

        [Test]
        public void Test3()
        {
            var tree = SyntaxTree.ParseCompilationUnit(@"var myVar = ""Hello World"";");
            Renamer r = new Renamer("var", "string");
            var newTree = r.Visit(tree.Root);
            Assert.AreEqual(@"string myVar = ""Hello World"";", newTree.ToString());
        }

        [Test]
        public void Test4()
        {
            var tree = SyntaxTree.ParseCompilationUnit(@"var myVar = ""Hello World"";");
            Renamer r = new Renamer("myvar", "newVar");
            var newTree = r.Visit(tree.Root);
            Assert.AreEqual(@"var myVar = ""Hello World"";", newTree.ToString());
        }

        [Test]
        public void Test5()
        {
            var tree = SyntaxTree.ParseCompilationUnit(@"var myVar = ""Hello World"";
                            mymyVar = ""some other var"";
                            mymyVar + myVar;
                            myVar + mymyVar;");
            Renamer r = new Renamer("myVar", "newVar");
            var newTree = r.Visit(tree.Root);
            Assert.AreEqual(@"var newVar = ""Hello World"";
                            mymyVar = ""some other var"";
                            mymyVar + newVar;
                            newVar + mymyVar;", newTree.ToString());
        }

        [Test]
        public void Test6()
        {
            var tree = SyntaxTree.ParseCompilationUnit(@"var my_var = ""Hello World"";");
            Renamer r = new Renamer("my_var", "new_var");
            var newTree = r.Visit(tree.Root);
            Assert.AreEqual(@"var new_var = ""Hello World"";", newTree.ToString());
        }

        [Test]
        public void Test7()
        {
            //text = r.Rename(@"/* this is a myVar */ var myVar = ""Hello World"";", "myVar", "newVar");
            //Assert.AreEqual(text, @"/* this is a newVar */ var newVar = ""Hello World"";");


            //text = r.Rename(@"var myVar = ""Hello World""; /* this is a myVar */", "myVar", "newVar");
            //Assert.AreEqual(text, @"var newVar = ""Hello World""; /* this is a newVar */");

            var tree = SyntaxTree.ParseCompilationUnit(@"/* this is a myVar */ var myVar = ""Hello World"";");
            Renamer r = new Renamer("myVar", "newVar");
            var newTree = r.Visit(tree.Root);
            Assert.AreEqual(@"/* this is a newVar */ var newVar = ""Hello World"";", newTree.ToString());
        }
    
    }
}

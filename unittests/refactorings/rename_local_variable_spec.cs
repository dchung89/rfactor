﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Roslyn.Compilers.Common;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.Editor;
using rfactor.lib.refactorings;

namespace Rfactor.UnitTests.refactorings
{
    [TestFixture]
    class rename_local_variable_spec
    {
        IWorkspace workspace;
        ISolution solution;
        IProject project;
        Symbol symbtolToReplace;

        [SetUp]
        public void GetContext()
        {
            workspace = Workspace.LoadSolution(@"../../testingfiles/SampleApplication.sln");
            solution = workspace.CurrentSolution;
            project = solution.Projects.First();

            ICompilation c = project.GetCompilation();
            INamespaceSymbol glob = c.Assembly.GlobalNamespace;
            var a = glob.GetNamespaceMembers();
        }

        [Test]
        public void BasicRename_01()
        {
            Assert.Ignore();
        }

        private NamedTypeSymbol FindSymbol(NamedTypeSymbol type)
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Services;
using Roslyn.Services.Editor;

namespace rfactor.lib
{
    class ContextFactory
    {
        IWorkspace iWorkspace;
        ISolution iSolution;

        public ContextFactory(IWorkspace iwork, ISolution isol)
        {
            this.iWorkspace = iwork;
            this.iSolution = isol;
        }

        public IWorkspace GetIWorkspace()
        {
            return this.iWorkspace;
        }

        public ISolution GetISolution()
        {
            return this.iSolution;
        }
}

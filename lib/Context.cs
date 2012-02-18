using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Services;
using Roslyn.Services.Editor;

namespace rfactor.lib
{
    class Context
    {
        IWorkspace iWorkspace;
        ISolution iSolution;
        IDocument iDocument;

        public Context(IWorkspace iwork, ISolution isol, IDocument idoc = null)
        {
            this.iWorkspace = iwork;
            this.iSolution = isol;
            this.iDocument = idoc;
        }

        public IWorkspace GetIWorkspace()
        {
            return this.iWorkspace;
        }

        public ISolution GetISolution()
        {
            return this.iSolution;
        }

        public IDocument getIDocument()
        {
            return this.iDocument;
        }
    }
}

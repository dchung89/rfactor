using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rfactor.lib;
using Roslyn.Services;
using Roslyn.Services.Editor;

namespace rfactor
{
    class RfactorController
    {
        ContextFactory ctxFactory;
        public RfactorController(IWorkspace iwork, ISolution isol)
        {
            ctxFactory = new ContextFactory(iwork, isol);
        }

        
    }
}

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
        RefactoringFactory refactoringFactory;

        public RfactorController(IWorkspace iwork, ISolution isol, IDocument idoc = null)
        {
            refactoringFactory = new RefactoringFactory(new Context(iwork, isol, idoc));
        }

        
    }
}

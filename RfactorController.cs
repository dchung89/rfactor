using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rfactor.Lib;
using Roslyn.Services;
using Roslyn.Services.Editor;

namespace Rfactor
{
    class RfactorController
    {
        RefactoringFactory refactoringFactory;

        public RfactorController(IWorkspace iwork, ISolution isol, IDocument idoc = null)
        {
            refactoringFactory = new RefactoringFactory(new Context(iwork, isol, idoc));
        }

        public RfactorController(Context ctx)
        {
            refactoringFactory = new RefactoringFactory(ctx);
        }
                
    }
}

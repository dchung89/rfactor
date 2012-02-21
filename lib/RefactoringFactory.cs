using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.Editor;
using Rfactor.Lib.Refactorings;

namespace Rfactor.Lib
{
    // Summary:
    //     The RefactoringFactory is responsible for maintaining a list of and making available all rfactor refactorings. 
    class RefactoringFactory
    {
        Context ctx;

        public RefactoringFactory(Context ctx)
        {
            this.ctx = ctx;
        }

        public Refactoring GetRenameLocalVariable(Symbol symbolToRename, String newName)
        {
            return new rename_local_variable(symbolToRename,newName,ctx);
        }
    }
}

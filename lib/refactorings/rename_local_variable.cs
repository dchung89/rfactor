using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.Editor;

namespace rfactor.lib.refactorings
{
    class rename_local_variable
    {
        [Import]
        private IRenameService iRenameService;
        public bool CheckPreconditions()
        {
            throw new NotImplementedException();
        }
        public SyntaxTree Refactor()
        {
            
            throw new NotImplementedException();
        }
    }
}

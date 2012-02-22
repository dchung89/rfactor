using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.Editor;
using Rfactor.Lib;

namespace Rfactor.Lib.Refactorings
{
    class rename_local_variable : Refactoring
    {

        public rename_local_variable(Symbol symbolToRename, String newName, Context ctxFactory)
            : base(ctxFactory)
        {
            this.symbolToRename = symbolToRename;
            this.newName = newName;
        }

        Symbol symbolToRename;
        String newName;

        [Import]
        private IRenameService iRenameService = null;

        public override bool CheckPreconditions()
        {
            throw new NotImplementedException();
        }
        public override SyntaxTree Refactor()
        {
            iRenameService.RenameSymbol(ctxFactory.GetIWorkspace(),ctxFactory.GetISolution(),symbolToRename,newName);
            return null;
        }
    }
}

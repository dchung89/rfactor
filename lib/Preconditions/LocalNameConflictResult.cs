using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Compilers;
using Roslyn.Compilers.Common;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.Editor;

namespace Rfactor.Lib.Preconditions
{
    class LocalNameConflictResult : IPreconditionResult
    {
        IEnumerable<SyntaxToken> conflicts;

        public LocalNameConflictResult()
        {
            this.conflicts = new List<SyntaxToken>();
        }

        public LocalNameConflictResult(IEnumerable<SyntaxToken> list)
        {
            this.conflicts = list;
        }

        public void AddConflict(SyntaxToken token)
        {
            ((List<SyntaxToken>)conflicts).Add(token);
        }

        public bool VerifySuccess()
        {
            if (this.conflicts.Count() == 0)
                return true;
            return false;
        }
    }
}

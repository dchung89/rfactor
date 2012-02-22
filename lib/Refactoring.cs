using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Roslyn.Services;
using Roslyn.Services.Editor;

namespace Rfactor.Lib
{
    // Summary:
    //     Abstract class representing a single Refactoring. It is responsible for maintaining a reference to a Context object, 
    //     as well as providing an interface for all refactorings to follow.
    abstract class Refactoring
    {
        protected Context ctxFactory;

        public Refactoring(Context ctxFactory)
        {
            this.ctxFactory = ctxFactory;
        }

        public virtual bool CheckPreconditions()
        {
            return false;
        }

        public abstract SyntaxTree Refactor();
    }
}

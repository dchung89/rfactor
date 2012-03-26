using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rfactor.Lib.Preconditions
{
    class GenericResult : IPreconditionResult
    {
        Result res;

        public GenericResult(Result res)
        {
            this.res = res;
        }

        public bool VerifySuccess()
        {
            if (this.res == Result.Success)
                return true;
            return false;
        }

        public Result GetResult()
        {
            return this.res;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rfactor.Lib.Preconditions
{
    enum Result
    {
        Success,
        LocalConflict,
        InheritedConflict
    };

    interface IPreconditionResult
    {
        bool VerifySuccess();
        Result GetResult();
    }
}

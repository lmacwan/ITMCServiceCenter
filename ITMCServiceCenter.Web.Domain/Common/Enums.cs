using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.Domain
{
    public enum ErrorCode
    {
        EmptyUsername = 0,
        EmptyPassword = 1,
        Disabled = 2,
        Invalid = 3
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.Cms.Core.Enums
{
    public enum EnumActionType
    {
        [Description("权限并日志")]
        AuthorizeAndLog = 0,
        [Description("权限")]
        Authorize = 1,
        [Description("日志")]
        Log = 2,
    }
}

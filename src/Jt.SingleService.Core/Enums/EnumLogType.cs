using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Enums
{
    public enum EnumLogType
    {
        [Description("操作日志")]
        OpLog = 1,
        [Description("异常日志")]
        ErrLog = 2,
    }
}

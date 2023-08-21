﻿using System.ComponentModel;

namespace Jt.SingleService.Core
{
    public enum EnumLogType
    {
        [Description("操作日志")]
        OpLog = 1,
        [Description("异常日志")]
        ErrLog = 2,
    }
}

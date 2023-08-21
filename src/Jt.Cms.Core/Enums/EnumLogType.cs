using System.ComponentModel;

namespace Jt.Cms.Core
{
    public enum EnumLogType
    {
        [Description("操作日志")]
        OpLog = 1,
        [Description("异常日志")]
        ErrLog = 2,
    }
}

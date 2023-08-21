using System.ComponentModel;

namespace Jt.Cms.Core
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

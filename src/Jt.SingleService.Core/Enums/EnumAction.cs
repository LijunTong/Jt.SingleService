using System.ComponentModel;

namespace Jt.SingleService.Core
{
    public enum EnumAction
    {
        [Description("显示")]
        Display = 0,
        [Description("新增")]
        Add = 1,
        [Description("修改")]
        Edit = 2,
        [Description("删除")]
        Delete = 3,
        [Description("查看")]
        Detials = 4,
        [Description("审核")]
        Audit = 5,
        [Description("导入")]
        Import = 6,
        [Description("导出")]
        Export = 7,
        [Description("同步数据")]
        SyncData = 8,
        [Description("连接")]
        Connect = 9,
        [Description("生成")]
        Generate = 10,
        [Description("绑定")]
        Bind = 11,
    }
}

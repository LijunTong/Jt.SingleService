using Jt.SingleService.Core.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = Jt.SingleService.Core.Tables.Action;

namespace Jt.SingleService.Service.MainSvc
{
    public interface IMainCacheSvc
    {
        /// <summary>
        /// 写入角色权限
        /// </summary>
        /// <param name="roleActions"></param>
        Task SetRoleActionsAsync(List<RoleAction> roleActions);

        /// <summary>
        /// 读取角色权限
        /// </summary>
        /// <returns></returns>
        Task<List<RoleAction>> GetRoleActionsAsync();

        /// <summary>
        /// 写入action
        /// </summary>
        /// <param name="actions"></param>
        Task SetActionsAsync(List<Action> actions);

        /// <summary>
        /// 读取action
        /// </summary>
        /// <returns></returns>
        Task<List<Action>> GetActionsAsync();

    }
}

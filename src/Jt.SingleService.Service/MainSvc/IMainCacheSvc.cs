using JT.Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = JT.Framework.Core.Model.Action;

namespace JT.Framework.Core.IService
{
    public interface IMainCacheSvc
    {
        /// <summary>
        /// 写入角色权限
        /// </summary>
        /// <param name="roleActions"></param>
        void SetRoleActions(List<RoleAction> roleActions);
        /// <summary>
        /// 读取角色权限
        /// </summary>
        /// <returns></returns>
        List<RoleAction> GetRoleActions();
        /// <summary>
        /// 写入action
        /// </summary>
        /// <param name="actions"></param>
        void SetActions(List<Action> actions);
        /// <summary>
        /// 读取action
        /// </summary>
        /// <returns></returns>
        List<Action> GetActions();
        
    }
}

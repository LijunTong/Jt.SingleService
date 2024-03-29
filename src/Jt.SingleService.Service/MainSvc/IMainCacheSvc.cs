﻿using Jt.SingleService.Core;
using Jt.SingleService.Data;
using Action = Jt.SingleService.Data.Action;
namespace Jt.SingleService.Service
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
        Task<ApiResponse<List<RoleAction>>> GetRoleActionsAsync();

        /// <summary>
        /// 写入action
        /// </summary>
        /// <param name="actions"></param>
        Task SetActionsAsync(List<Action> actions);

        /// <summary>
        /// 读取action
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse<List<Action>>> GetActionsAsync();

    }
}

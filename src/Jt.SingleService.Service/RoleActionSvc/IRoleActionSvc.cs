using Jt.SingleService.Core.Dto;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Service.RoleActionSvc
{
    public interface IRoleActionSvc : IBaseSvc<RoleAction>
    {
        Task BindRoleActionsAsync(RoleActionDto roleActionDto);

        Task<List<RoleAction>> GetRoleActionsAsync(int roleId);

        Task LoadRoleActionsRedisAsync();
    }
}
using Jt.SingleService.Data.Dto;
using Jt.SingleService.Data.Tables;

namespace Jt.SingleService.Service.RoleActionSvc
{
    public interface IRoleActionSvc : IBaseSvc<RoleAction>
    {
        Task BindRoleActionsAsync(RoleActionDto roleActionDto);

        Task<List<RoleAction>> GetRoleActionsAsync(string roleId);

        Task LoadRoleActionsRedisAsync();
    }
}
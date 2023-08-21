using Jt.SingleService.Core;
using Jt.SingleService.Data;
namespace Jt.SingleService.Service
{
    public interface IRoleActionSvc : IBaseSvc<RoleAction>
    {
        Task BindRoleActionsAsync(RoleActionDto roleActionDto);

        Task<ApiResponse<List<RoleAction>>> GetRoleActionsAsync(string roleId);

        Task LoadRoleActionsRedisAsync();
    }
}
using Jt.Cms.Core;
using Jt.Cms.Data;
namespace Jt.Cms.Service
{
    public interface IRoleActionSvc : IBaseSvc<RoleAction>
    {
        Task BindRoleActionsAsync(RoleActionDto roleActionDto);

        Task<ApiResponse<List<RoleAction>>> GetRoleActionsAsync(string roleId);

        Task LoadRoleActionsRedisAsync();
    }
}
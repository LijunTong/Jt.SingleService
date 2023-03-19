using Jt.Cms.Data.Dto;
using Jt.Cms.Data.Tables;

namespace Jt.Cms.Service.RoleActionSvc
{
    public interface IRoleActionSvc : IBaseSvc<RoleAction>
    {
        Task BindRoleActionsAsync(RoleActionDto roleActionDto);

        Task<List<RoleAction>> GetRoleActionsAsync(string roleId);

        Task LoadRoleActionsRedisAsync();
    }
}
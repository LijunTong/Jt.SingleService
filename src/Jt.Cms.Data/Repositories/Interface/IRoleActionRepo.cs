using Jt.Cms.Data.Tables;

namespace Jt.Cms.Data.Repositories.Interface
{
    public interface IRoleActionRepo : IBaseRepo<RoleAction>
    {
        Task<List<RoleAction>> GetRoleActionsAsync(int roleId);
    }
}
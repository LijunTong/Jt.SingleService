using Jt.SingleService.Data.Tables;

namespace Jt.SingleService.Data.Repositories.Interface
{
    public interface IRoleActionRepo : IBaseRepo<RoleAction>
    {
        Task<List<RoleAction>> GetRoleActionsAsync(int roleId);
    }
}
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Core.Repositories;

namespace Jt.SingleService.Core.Repositories
{
    public interface IRoleActionRepo : IBaseRepo<RoleAction>
    {
        Task<List<RoleAction>> GetRoleActionsAsync(int roleId);
    }
}
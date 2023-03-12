using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Service.RoleSvc
{
    public interface IRoleSvc : IBaseSvc<Role>
    {
        Task<Role> GetRoleAsync(string code);

        Task<List<Role>> GetRolesAsync(int userId);
    }
}
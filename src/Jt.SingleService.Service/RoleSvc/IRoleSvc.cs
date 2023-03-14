using Jt.SingleService.Data.Tables;

namespace Jt.SingleService.Service.RoleSvc
{
    public interface IRoleSvc : IBaseSvc<Role>
    {
        Task<Role> GetRoleAsync(string code);

        Task<List<Role>> GetRolesAsync(string userId);
    }
}
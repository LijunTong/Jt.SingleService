using Jt.Cms.Data.Tables;

namespace Jt.Cms.Service.RoleSvc
{
    public interface IRoleSvc : IBaseSvc<Role>
    {
        Task<Role> GetRoleAsync(string code);

        Task<List<Role>> GetRolesAsync(string userId);
    }
}
using Jt.Cms.Core;
using Jt.Cms.Data;
namespace Jt.Cms.Service
{
    public interface IRoleSvc : IBaseSvc<Role>
    {
        Task<ApiResponse<Role>> GetRoleAsync(string code);

        Task<ApiResponse<List<Role>>> GetRolesAsync(string userId);
    }
}
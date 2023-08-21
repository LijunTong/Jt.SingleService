using Jt.SingleService.Core;
using Jt.SingleService.Data;
namespace Jt.SingleService.Service
{
    public interface IRoleSvc : IBaseSvc<Role>
    {
        Task<ApiResponse<Role>> GetRoleAsync(string code);

        Task<ApiResponse<List<Role>>> GetRolesAsync(string userId);
    }
}
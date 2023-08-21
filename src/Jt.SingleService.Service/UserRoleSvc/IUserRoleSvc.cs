using Jt.SingleService.Core;
using Jt.SingleService.Data;
namespace Jt.SingleService.Service
{
    public interface IUserRoleSvc : IBaseSvc<UserRole>
    {
        Task BindUserRoleAsync(UserRoleDto userRoleDto);

        Task<ApiResponse<List<UserRole>>> GetUserRolesAsync(string userId);
    }
}
using Jt.Cms.Core;
using Jt.Cms.Data;
namespace Jt.Cms.Service
{
    public interface IUserRoleSvc : IBaseSvc<UserRole>
    {
        Task BindUserRoleAsync(UserRoleDto userRoleDto);

        Task<ApiResponse<List<UserRole>>> GetUserRolesAsync(string userId);
    }
}
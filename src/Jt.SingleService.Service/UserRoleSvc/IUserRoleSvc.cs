using Jt.SingleService.Core.Dto;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Service.UserRoleSvc
{
    public interface IUserRoleSvc : IBaseSvc<UserRole>
    {
        Task BindUserRoleAsync(UserRoleDto userRoleDto);

        Task<List<UserRole>> GetUserRolesAsync(int userId);
    }
}
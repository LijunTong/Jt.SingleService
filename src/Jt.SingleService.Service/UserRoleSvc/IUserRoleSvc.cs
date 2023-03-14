using Jt.SingleService.Data.Dto;
using Jt.SingleService.Data.Tables;

namespace Jt.SingleService.Service.UserRoleSvc
{
    public interface IUserRoleSvc : IBaseSvc<UserRole>
    {
        Task BindUserRoleAsync(UserRoleDto userRoleDto);

        Task<List<UserRole>> GetUserRolesAsync(string userId);
    }
}
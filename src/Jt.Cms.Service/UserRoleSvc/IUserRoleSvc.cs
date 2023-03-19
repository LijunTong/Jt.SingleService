using Jt.Cms.Data.Dto;
using Jt.Cms.Data.Tables;

namespace Jt.Cms.Service.UserRoleSvc
{
    public interface IUserRoleSvc : IBaseSvc<UserRole>
    {
        Task BindUserRoleAsync(UserRoleDto userRoleDto);

        Task<List<UserRole>> GetUserRolesAsync(string userId);
    }
}
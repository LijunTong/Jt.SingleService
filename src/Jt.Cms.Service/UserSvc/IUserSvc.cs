using Jt.Cms.Core.Models;
using Jt.Cms.Data.Dto;
using Jt.Cms.Data.Tables;

namespace Jt.Cms.Service.UserSvc
{
    public interface IUserSvc : IBaseSvc<User>
    {
        Task<User> GetUserByNameAsync(string userName);

        Task<bool> CheckUserNameExistsAsync(string userName);

        Task<ApiResponse<bool>> RegisterAsync(User user);

        Task<GetUserInfoOutput> GetUserInfoAsync(string id);
    }
}
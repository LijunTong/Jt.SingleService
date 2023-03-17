using Jt.SingleService.Core.Models;
using Jt.SingleService.Data.Dto;
using Jt.SingleService.Data.Tables;

namespace Jt.SingleService.Service.UserSvc
{
    public interface IUserSvc : IBaseSvc<User>
    {
        Task<User> GetUserByNameAsync(string userName);

        Task<bool> CheckUserNameExistsAsync(string userName);

        Task<ApiResponse<bool>> RegisterAsync(User user);

        Task<GetUserInfoOutput> GetUserInfoAsync(string id);
    }
}
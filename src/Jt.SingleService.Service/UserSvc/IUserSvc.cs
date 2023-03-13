using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Service.UserSvc
{
    public interface IUserSvc : IBaseSvc<User>
    {
        Task<User> GetUserByNameAsync(string userName);

        Task<bool> CheckUserNameExistsAsync(string userName);

        Task<ApiResponse<bool>> RegisterAsync(User user);
    }
}
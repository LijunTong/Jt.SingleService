using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Service.UserSvc
{
    public interface IUserSvc : IBaseSvc<User>
    {
        Task<User> GetUserByNameAsync(string userName);

        Task<bool> CheckUserNameExistsAsync(string userName);

        void RegisteAsyncr(User user);
    }
}
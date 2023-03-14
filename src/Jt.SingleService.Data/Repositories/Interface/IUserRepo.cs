using Jt.SingleService.Data.Tables;

namespace Jt.SingleService.Data.Repositories.Interface
{
    public interface IUserRepo : IBaseRepo<User>
    {
        Task<User> GetUserByNameAsync(string userName);
    }
}
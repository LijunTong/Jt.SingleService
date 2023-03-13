using Jt.SingleService.Core.Tables;
using Jt.SingleService.Core.Repositories;

namespace Jt.SingleService.Core.Repositories
{
    public interface IUserRepo : IBaseRepo<User>
    {
        Task<User> GetUserByNameAsync(string userName);
    }
}
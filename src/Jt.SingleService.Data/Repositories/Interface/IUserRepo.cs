using Jt.SingleService.Data.Dto.User.Req;
using Jt.SingleService.Data.Tables;

namespace Jt.SingleService.Data.Repositories.Interface
{
    public interface IUserRepo : IBaseRepo<User>
    {
        Task<User> GetUserByNameAsync(string userName);

        Task<List<User>> GetPagerListAsync(GetPagerListReq req);

        Task<User> GetUserAsync(string id);
    }
}
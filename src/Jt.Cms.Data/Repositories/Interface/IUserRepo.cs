using Jt.Cms.Data.Tables;

namespace Jt.Cms.Data.Repositories.Interface
{
    public interface IUserRepo : IBaseRepo<User>
    {
        Task<User> GetUserByNameAsync(string userName);
    }
}
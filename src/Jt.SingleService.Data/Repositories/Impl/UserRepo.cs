using Jt.SingleService.Data.DbContexts;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Data.Repositories.Interface;
using Jt.SingleService.Lib.DI;

namespace Jt.SingleService.Data.Repositories.Impl
{
    public class UserRepo : BaseRepo<User>, IUserRepo, ITransientInterface
    {
        public UserRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await GetFirstAsync(x => x.UserName == userName);
        }
    }
}

using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Data.Repositories
{
    public class UserRepo : BaseRepo<User>, IUserRepo, ITransientInterface
    {
        public UserRepo (MysqlDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await base.GetFirstAsync(x => x.UserName == userName);
        }
    }
}

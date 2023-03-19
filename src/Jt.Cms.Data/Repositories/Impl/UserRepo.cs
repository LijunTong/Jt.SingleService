using Jt.Cms.Data.DbContexts;
using Jt.Cms.Data.Tables;
using Jt.Cms.Data.Repositories.Interface;
using Jt.Cms.Lib.DI;

namespace Jt.Cms.Data.Repositories.Impl
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

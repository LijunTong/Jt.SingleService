using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Data.Repositories
{
    public class UserRepo : BaseRepo<User>, IUserRepo
    {
        public UserRepo (MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

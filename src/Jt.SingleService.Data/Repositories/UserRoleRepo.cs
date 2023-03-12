using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Data.Repositories
{
    public class UserRoleRepo : BaseRepo<UserRole>, IUserRoleRepo
    {
        public UserRoleRepo (MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Data.Repositories
{
    public class RoleRepo : BaseRepo<Role>, IRoleRepo
    {
        public RoleRepo (MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

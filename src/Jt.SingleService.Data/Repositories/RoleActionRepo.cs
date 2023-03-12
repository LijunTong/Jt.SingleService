using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Data.Repositories
{
    public class RoleActionRepo : BaseRepo<RoleAction>, IRoleActionRepo
    {
        public RoleActionRepo (MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Data.Repositories
{
    public class SysLogRepo : BaseRepo<SysLog>, ISysLogRepo
    {
        public SysLogRepo (MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

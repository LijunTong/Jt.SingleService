using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Data.Repositories
{
    public class ActionRepo : BaseRepo<Core.Tables.Action>, IActionRepo
    {
        public ActionRepo (MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

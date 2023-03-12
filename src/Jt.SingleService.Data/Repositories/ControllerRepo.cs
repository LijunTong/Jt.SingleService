using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Data.Repositories
{
    public class ControllerRepo : BaseRepo<Controller>, IControllerRepo
    {
        public ControllerRepo (MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

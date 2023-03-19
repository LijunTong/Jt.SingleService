using Jt.SingleService.Data.DbContexts;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Data.Repositories.Interface;
using Jt.SingleService.Lib.DI;

namespace Jt.SingleService.Data.Repositories.Impl
{
    public class ControllerRepo : BaseRepo<Controller>, IControllerRepo, ITransientInterface
    {
        public ControllerRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}
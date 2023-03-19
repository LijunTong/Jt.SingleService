using Jt.SingleService.Data.DbContexts;
using Jt.SingleService.Data.Repositories.Interface;
using Jt.SingleService.Lib.DI;
using Action = Jt.SingleService.Data.Tables.Action;

namespace Jt.SingleService.Data.Repositories.Impl
{
    public class ActionRepo : BaseRepo<Action>, IActionRepo, ITransientInterface
    {
        public ActionRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

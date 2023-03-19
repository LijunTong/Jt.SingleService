using Jt.Cms.Data.DbContexts;
using Jt.Cms.Data.Repositories.Interface;
using Jt.Cms.Lib.DI;
using Action = Jt.Cms.Data.Tables.Action;

namespace Jt.Cms.Data.Repositories.Impl
{
    public class ActionRepo : BaseRepo<Action>, IActionRepo, ITransientInterface
    {
        public ActionRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

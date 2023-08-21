using Jt.Common.Tool.DI;
namespace Jt.Cms.Data
{
    public class ActionRepo : BaseRepo<Action>, IActionRepo, ITransientDIInterface
    {
        public ActionRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

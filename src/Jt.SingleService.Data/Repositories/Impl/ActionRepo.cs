using Jt.Common.Tool.DI;
namespace Jt.SingleService.Data
{
    public class ActionRepo : BaseRepo<Action>, IActionRepo, ITransientDIInterface
    {
        public ActionRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

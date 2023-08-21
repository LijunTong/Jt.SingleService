using Jt.Common.Tool.DI;

namespace Jt.SingleService.Data
{
    public class ControllerRepo : BaseRepo<Controller>, IControllerRepo, ITransientDIInterface
    {
        public ControllerRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

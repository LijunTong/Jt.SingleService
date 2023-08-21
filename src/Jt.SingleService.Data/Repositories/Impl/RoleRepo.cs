using Jt.Common.Tool.DI;

namespace Jt.SingleService.Data
{
    public class RoleRepo : BaseRepo<Role>, IRoleRepo, ITransientDIInterface
    {
        public RoleRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

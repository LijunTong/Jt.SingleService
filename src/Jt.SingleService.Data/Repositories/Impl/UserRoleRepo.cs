using Jt.Common.Tool.DI;

namespace Jt.SingleService.Data
{
    public class UserRoleRepo : BaseRepo<UserRole>, IUserRoleRepo, ITransientDIInterface
    {
        public UserRoleRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

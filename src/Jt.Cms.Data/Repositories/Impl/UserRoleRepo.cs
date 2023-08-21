using Jt.Common.Tool.DI;

namespace Jt.Cms.Data
{
    public class UserRoleRepo : BaseRepo<UserRole>, IUserRoleRepo, ITransientDIInterface
    {
        public UserRoleRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

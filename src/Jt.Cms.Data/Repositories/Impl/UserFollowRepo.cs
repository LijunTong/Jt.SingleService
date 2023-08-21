using Jt.Common.Tool.DI;

namespace Jt.Cms.Data
{
    public class UserFollowRepo : BaseRepo<UserFollow>, IUserFollowRepo, ITransientDIInterface
    {
        public UserFollowRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

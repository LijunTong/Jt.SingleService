using Jt.Cms.Data.DbContexts;
using Jt.Cms.Data.Tables;
using Jt.Cms.Data.Repositories.Interface;
using Jt.Cms.Lib.DI;

namespace Jt.Cms.Data.Repositories.Impl
{
    public class RoleRepo : BaseRepo<Role>, IRoleRepo, ITransientInterface
    {
        public RoleRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

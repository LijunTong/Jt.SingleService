using Jt.Cms.Data.DbContexts;
using Jt.Cms.Data.Tables;
using Jt.Cms.Data.Repositories.Interface;
using Jt.Cms.Lib.DI;

namespace Jt.Cms.Data.Repositories.Impl
{
    public class MenuRepo : BaseRepo<Menu>, IMenuRepo, ITransientInterface
    {
        public MenuRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Menu> GetMenuByNameAsync(string name)
        {
            return await GetFirstAsync(x => x.Name == name);
        }
    }
}

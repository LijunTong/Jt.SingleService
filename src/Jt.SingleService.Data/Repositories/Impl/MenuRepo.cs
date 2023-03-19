using Jt.SingleService.Data.DbContexts;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Data.Repositories.Interface;
using Jt.SingleService.Lib.DI;

namespace Jt.SingleService.Data.Repositories.Impl
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

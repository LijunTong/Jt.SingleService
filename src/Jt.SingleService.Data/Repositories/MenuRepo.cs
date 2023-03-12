using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Data.Repositories
{
    public class MenuRepo : BaseRepo<Menu>, IMenuRepo
    {
        public MenuRepo (MysqlDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Menu> GetMenuByNameAsync(string name)
        {
            return await base.GetFirstAsync(x => x.Name == name);
        }
    }
}

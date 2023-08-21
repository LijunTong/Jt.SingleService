using Jt.Common.Tool.DI;

namespace Jt.Cms.Data
{
    public class MenuRepo : BaseRepo<Menu>, IMenuRepo, ITransientDIInterface
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

using Jt.Cms.Data.Tables;

namespace Jt.Cms.Data.Repositories.Interface
{
    public interface IMenuRepo : IBaseRepo<Menu>
    {
        Task<Menu> GetMenuByNameAsync(string name);
    }
}
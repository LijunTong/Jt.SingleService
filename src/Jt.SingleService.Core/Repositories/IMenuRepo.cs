using Jt.SingleService.Core.Tables;
using Jt.SingleService.Core.Repositories;

namespace Jt.SingleService.Core.Repositories
{
    public interface IMenuRepo : IBaseRepo<Menu>
    {
        Task<Menu> GetMenuByNameAsync(string name);
    }
}
namespace Jt.SingleService.Data
{
    public interface IMenuRepo : IBaseRepo<Menu>
    {
        Task<Menu> GetMenuByNameAsync(string name);
    }
}
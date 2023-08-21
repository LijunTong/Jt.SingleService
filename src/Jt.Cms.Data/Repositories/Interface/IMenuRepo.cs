namespace Jt.Cms.Data
{
    public interface IMenuRepo : IBaseRepo<Menu>
    {
        Task<Menu> GetMenuByNameAsync(string name);
    }
}
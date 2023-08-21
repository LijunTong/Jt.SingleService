namespace Jt.Cms.Data
{
    public interface IUserRepo : IBaseRepo<User>
    {
        Task<User> GetUserByNameAsync(string userName);

        Task<List<User>> GetPagerListAsync(GetPagerListReq req);

        Task<User> GetUserAsync(string id);
    }
}
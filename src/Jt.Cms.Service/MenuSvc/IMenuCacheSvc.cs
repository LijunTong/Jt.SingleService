namespace Jt.Cms.Service
{
    public interface IMenuCacheSvc
    {
        Task SetControllerAsync(List<string> controllers);

        Task<List<string>> GetControllerAsync();
    }
}

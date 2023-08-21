namespace Jt.SingleService.Service
{
    public interface IMenuCacheSvc
    {
        Task SetControllerAsync(List<string> controllers);

        Task<List<string>> GetControllerAsync();
    }
}

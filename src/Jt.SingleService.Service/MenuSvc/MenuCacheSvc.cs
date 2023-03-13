using Jt.SingleService.Core.Cache;
using Jt.SingleService.Core.DI;

namespace Jt.SingleService.Service.MenuSvc
{
    public class MenuCacheSvc : IMenuCacheSvc, ITransientInterface
    {
        private readonly string KeyController = "KeyController";
        private ICacheSvc _cacheSvc;

        public MenuCacheSvc(ICacheSvc CacheSvc)
        {
            _cacheSvc = CacheSvc;
        }



        public async Task SetControllerAsync(List<string> controllers)
        {
            await _cacheSvc.AddAsync(KeyController, controllers);
        }

        public async Task<List<string>> GetControllerAsync()
        {
            return await _cacheSvc.GetAsync<List<string>>(KeyController);
        }


    }
}

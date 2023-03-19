using Jt.Cms.Core.Cache;
using Jt.Cms.Lib.DI;

namespace Jt.Cms.Service.MenuSvc
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

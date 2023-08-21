using Jt.Cms.Core;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class MenuCacheSvc : IMenuCacheSvc, ITransientDIInterface
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

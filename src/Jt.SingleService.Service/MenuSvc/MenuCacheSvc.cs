using JT.Framework.Core.IService;
using JT.Framework.Library.CommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT.Framework.Core.Service
{
    public class MenuCacheSvc : IMenuCacheSvc
    {
        private readonly string KeyController = "KeyController";
        private ICacheService _cacheService;

        public MenuCacheSvc(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        

        public void SetController(List<string> controllers)
        {
            _cacheService.Add(KeyController, controllers);
        }
        public List<string> GetController()
        {
            return _cacheService.Get<List<string>>(KeyController);
        }


    }
}

using JT.Framework.Core.IService;
using JT.Framework.Core.Model;
using JT.Framework.Library.CommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = JT.Framework.Core.Model.Action;

namespace JT.Framework.Core.Service
{
    public class MainCacheSvc: IMainCacheSvc
    {
        private ICacheService _cacheService;
        private readonly string KeyRoleAction = "KeyRoleAction"; 
        private readonly string KeyAction = "KeyAction";
        

        public MainCacheSvc(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public void SetRoleActions(List<RoleAction> roleActions)
        {
            _cacheService.Add(KeyRoleAction, roleActions);
        }
        public List<RoleAction> GetRoleActions()
        {
            return _cacheService.Get<List<RoleAction>>(KeyRoleAction);
        }

        public void SetActions(List<Action> actions)
        {
            _cacheService.Add(KeyAction, actions);
        }

        public List<Action> GetActions()
        {
            return _cacheService.Get<List<Action>>(KeyAction);
        }

    }
}


using Jt.Cms.Core.Cache;
using Jt.Cms.Data.Tables;
using Jt.Cms.Lib.DI;
using Action = Jt.Cms.Data.Tables.Action;

namespace Jt.Cms.Service.MainSvc
{
    public class MainCacheSvc : IMainCacheSvc, ITransientInterface
    {
        private ICacheSvc _cacheSvc;
        private readonly string KeyRoleAction = "KeyRoleAction";
        private readonly string KeyAction = "KeyAction";


        public MainCacheSvc(ICacheSvc cacheSvc)
        {
            _cacheSvc = cacheSvc;
        }

        public async Task SetRoleActionsAsync(List<RoleAction> roleActions)
        {
            await _cacheSvc.AddAsync(KeyRoleAction, roleActions);
        }
        public Task<List<RoleAction>> GetRoleActionsAsync()
        {
            return _cacheSvc.GetAsync<List<RoleAction>>(KeyRoleAction);
        }

        public async Task SetActionsAsync(List<Action> actions)
        {
            await _cacheSvc.AddAsync(KeyAction, actions);
        }

        public Task<List<Action>> GetActionsAsync()
        {
            return _cacheSvc.GetAsync<List<Action>>(KeyAction);
        }

    }
}

using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Common.Tool.DI;
using Action = Jt.Cms.Data.Action;
namespace Jt.Cms.Service
{
    public class MainCacheSvc : IMainCacheSvc, ITransientDIInterface
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

        public async Task<ApiResponse<List<RoleAction>>> GetRoleActionsAsync()
        {
            var data = await _cacheSvc.GetAsync<List<RoleAction>>(KeyRoleAction);
            return ApiResponse<List<RoleAction>>.Succeed(data);
        }

        public async Task SetActionsAsync(List<Action> actions)
        {
            await _cacheSvc.AddAsync(KeyAction, actions);
        }

        public async Task<ApiResponse<List<Action>>> GetActionsAsync()
        {
            var data = await _cacheSvc.GetAsync<List<Action>>(KeyAction);
            return ApiResponse<List<Action>>.Succeed(data);
        }

    }
}

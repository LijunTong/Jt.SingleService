using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Dto;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.MainSvc;
using Jt.SingleService.Service.RoleActionSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class RoleActionSvc : BaseSvc<RoleAction>, IRoleActionSvc, ITransientInterface
    {
        private readonly IRoleActionRepo _repository;
        private readonly IMainCacheSvc _mainCacheSvc;

        public RoleActionSvc(IRoleActionRepo repository, IMainCacheSvc mainCacheSvc) : base(repository)
        {
            _repository = repository;
            _mainCacheSvc = mainCacheSvc;
        }

        public async Task BindRoleActionsAsync(RoleActionDto roleActionDto)
        {
            if (roleActionDto != null)
            {
                await _repository.DeleteAsync(x => x.RoleId == roleActionDto.RoleId);
                List<RoleAction> roleActions = new List<RoleAction>();
                roleActionDto.Actions.ForEach(x =>
                {
                    roleActions.Add(new RoleAction
                    {
                        RoleId = roleActionDto.RoleId,
                        Controller = x.Controller,
                        Action = x.Action,
                        CreateTime = DateTime.Now,
                        Creater = "",
                        UpTime = DateTime.Now,
                        Updater = ""
                    });
                });
               await _repository.InsertListAsync(roleActions);
              await  _repository.SaveAsync();
            }
        }

        public async Task<List<RoleAction>> GetRoleActionsAsync(string roleId)
        {
            var roleActions = await _repository.GetListAsync(x => x.RoleId == roleId);

            return roleActions;
        }

        public async Task LoadRoleActionsRedisAsync()
        {
            await _mainCacheSvc.SetRoleActionsAsync(await GetAllListAsync());
        }
    }
}

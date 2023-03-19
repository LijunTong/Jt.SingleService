using Jt.Cms.Data.Dto;
using Jt.Cms.Data.Tables;
using Jt.Cms.Data.Repositories.Interface;
using Jt.Cms.Service.MainSvc;
using Jt.Cms.Service.RoleActionSvc;
using Jt.Cms.Lib.DI;
using Jt.Cms.Lib.Utils;

namespace Jt.Cms.Service.UserSvc
{
    public class RoleActionSvc : BaseSvc<RoleAction>, IRoleActionSvc, ITransientInterface
    {
        private readonly IRoleActionRepo _repository;
        private readonly IMainCacheSvc _mainCacheSvc;
        private readonly CHelperSnowflake _snowflake;

        public RoleActionSvc(IRoleActionRepo repository, IMainCacheSvc mainCacheSvc, CHelperSnowflake snowflake) : base(repository)
        {
            _repository = repository;
            _mainCacheSvc = mainCacheSvc;
            _snowflake = snowflake;
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
                        Id = _snowflake.NextId().ToString(),
                        RoleId = roleActionDto.RoleId,
                        Controller = x.Controller,
                        Action = x.Action,
                        CreateTime = DateTime.Now,
                        Creater = roleActionDto.UserId,
                        UpTime = DateTime.Now,
                        Updater = roleActionDto.UserId
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

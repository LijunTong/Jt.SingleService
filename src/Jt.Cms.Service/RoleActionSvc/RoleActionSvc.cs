using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class RoleActionSvc : BaseSvc<RoleAction>, IRoleActionSvc, ITransientDIInterface
    {
        private readonly IRoleActionRepo _repository;
        private readonly IMainCacheSvc _mainCacheSvc;
        private readonly IIDSvc _snowflake;

        public RoleActionSvc(IRoleActionRepo repository, IMainCacheSvc mainCacheSvc, IIDSvc snowflake) : base(repository)
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
                await _repository.SaveAsync();
            }
        }

        public async Task<ApiResponse<List<RoleAction>>> GetRoleActionsAsync(string roleId)
        {
            var roleActions = await _repository.GetListAsync(x => x.RoleId == roleId);
            return ApiResponse<List<RoleAction>>.Succeed(roleActions);
        }

        public async Task LoadRoleActionsRedisAsync()
        {
            var data = await GetAllListAsync();
            await _mainCacheSvc.SetRoleActionsAsync(data.Data);
        }
    }
}

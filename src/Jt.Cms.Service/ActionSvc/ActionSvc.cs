using Jt.Cms.Core.Attributes;
using Jt.Cms.Core.Enums;
using Jt.Cms.Data.Repositories.Interface;
using Jt.Cms.Data.Tables;
using Jt.Cms.Lib.DI;
using Jt.Cms.Lib.Utils;
using Jt.Cms.Service.ActionSvc;
using System.Reflection;
using Action = Jt.Cms.Data.Tables.Action;

namespace Jt.Cms.Service.UserSvc
{
    public class ActionSvc : BaseSvc<Action>, IActionSvc, ITransientInterface
    {
        private readonly IActionRepo _repository;
        private readonly CHelperSnowflake _snowflake;

        public ActionSvc(IActionRepo repository, CHelperSnowflake snowflake) : base(repository)
        {
            _repository = repository;
            _snowflake = snowflake;
        }

        public async Task<List<Action>> GetActionsAsync(string controller)
        {
            return await _repository.GetListAsync(x => x.Controller == controller);
        }

        public async Task InitActionsAsync()
        {
            Assembly[] assembly = AppDomain.CurrentDomain.GetAssemblies();
            var types = CHelperAssembly.GetTypesByAttribute(assembly, typeof(AuthorControllerAttribute));
            if (types != null)
            {
                var existsActions = await GetAllListAsync();
                List<Action> addActions = new List<Action>();
                foreach (var item in types)
                {
                    var methods = CHelperAssembly.GetMethodInfosWithAttribute(item, typeof(ActionAttribute));
                    foreach (var method in methods)
                    {
                        if (!existsActions.Any(x => x.Controller == item.Name && x.Name == method.Name))
                        {
                            var attr = (ActionAttribute)method.GetCustomAttribute(typeof(ActionAttribute));
                            if (attr != null && attr.ActionType != EnumActionType.Log)
                            {
                                Action action = new Action()
                                {
                                    Id = _snowflake.NextId().ToString(),
                                    Controller = item.Name,
                                    Name = method.Name,
                                    Text = attr.Text ?? method.Name,
                                    Creater = "系统",
                                    CreateTime = DateTime.Now,
                                    Updater = "系统",
                                    UpTime = DateTime.Now,
                                };
                                addActions.Add(action);
                            }
                        }
                    }
                }
                List<Action> delActions = new List<Action>();
                foreach (var action in existsActions)
                {
                    foreach (var item in types)
                    {
                        var methods = CHelperAssembly.GetMethodInfosWithAttribute(item, typeof(ActionAttribute));
                        foreach (var method in methods)
                        {
                            if (!existsActions.Any(x => x.Controller == item.Name && x.Name == method.Name))
                            {
                                delActions.Add(action);
                            }
                        }
                    }
                }

                if (addActions.Any())
                {
                    await _repository.InsertListAsync(addActions);
                }
                if (delActions.Any())
                {
                    await _repository.DeleteAsync(x => delActions.Where(o => o.Id == x.Id).Count() > 0);
                }
                await _repository.SaveAsync();
            }
        }

        public Task LoadActionsRedisAsync()
        {
            throw new NotImplementedException();
        }
    }
}

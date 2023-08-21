using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Common.Tool.DI;
using Jt.Common.Tool.Helper;
using System.Reflection;
using Action = Jt.Cms.Data.Action;

namespace Jt.Cms.Service
{
    public class ActionSvc : BaseSvc<Action>, IActionSvc, ITransientDIInterface
    {
        private readonly IActionRepo _repository;
        private readonly IIDSvc _snowflake;

        public ActionSvc(IActionRepo repository, IIDSvc snowflake) : base(repository)
        {
            _repository = repository;
            _snowflake = snowflake;
        }

        public async Task<ApiResponse<List<Action>>> GetActionsAsync(string controller)
        {
            var data = await _repository.GetListAsync(x => x.Controller == controller);
            return ApiResponse<List<Action>>.Succeed(data);
        }

        public async Task InitActionsAsync()
        {
            Assembly[] assembly = AppDomain.CurrentDomain.GetAssemblies();
            var types = AssemblyHelper.GetTypesByAttribute(assembly, typeof(AuthorControllerAttribute));

            if (types != null)
            {
                var existsActions = (await GetAllListAsync()).Data;
                List<Action> addActions = new List<Action>();
                foreach (var item in types)
                {
                    var methods = AssemblyHelper.GetMethodInfosWithAttribute(item, typeof(ActionAttribute));
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
                List<MethodInfo> methhods = new List<MethodInfo>();
                foreach (var item in types)
                {
                    var methods = AssemblyHelper.GetMethodInfosWithAttribute(item, typeof(ActionAttribute));
                    foreach (var method in methods)
                    {
                        methhods.Add(method);

                    }
                }
                foreach (var action in existsActions)
                {
                    if (!methhods.Any(x => x.DeclaringType.Name == action.Controller && x.Name == action.Name))
                    {
                        delActions.Add(action);
                    }
                }

                if (addActions.Any())
                {
                    await _repository.InsertListAsync(addActions);
                }
                if (delActions.Any())
                {
                    List<string> ids = delActions.Select(x => x.Id).ToList();
                    await _repository.DeleteAsync(x => ids.Contains(x.Id));
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

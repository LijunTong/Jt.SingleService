using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Common.Tool.DI;
using Jt.Common.Tool.Helper;
using System.Reflection;

namespace Jt.Cms.Service
{
    public class ControllerSvc : BaseSvc<Controller>, IControllerSvc, ITransientDIInterface
    {
        private readonly IControllerRepo _repository;
        private readonly IIDSvc _snowflake;

        public ControllerSvc(IControllerRepo repository, IIDSvc snowflake) : base(repository)
        {
            _repository = repository;
            _snowflake = snowflake;
        }

        public async Task<ApiResponse<List<Controller>>> GetControllersAsync()
        {
            var data = await _repository.GetListAsync();
            return ApiResponse<List<Controller>>.Succeed(data);
        }

        public async Task InitControllerAsync()
        {
            Assembly[] assembly = AppDomain.CurrentDomain.GetAssemblies();
            var types = AssemblyHelper.GetTypesByAttribute(assembly, typeof(AuthorControllerAttribute));
            if (types != null)
            {
                var existsControllers = (await GetAllListAsync()).Data;

                List<Controller> addControllers = new List<Controller>();
                foreach (var item in types)
                {
                    if (!existsControllers.Any(x => x.Name == item.Name))
                    {
                        var controller = new Controller()
                        {
                            Id = _snowflake.NextId().ToString(),
                            Name = item.Name,
                            CreateTime = DateTime.Now,
                            Creater = "系统",
                            Updater = "系统",
                            UpTime = DateTime.Now,
                        };
                        addControllers.Add(controller);
                    }
                }
                List<Controller> delControllers = new List<Controller>();
                foreach (var item in existsControllers)
                {
                    if (!types.Any(x => x.Name == item.Name))
                    {
                        delControllers.Add(item);
                    }
                }
                if (addControllers.Any())
                {
                    await _repository.InsertListAsync(addControllers);
                }
                if (delControllers.Any())
                {
                    List<string> ids = delControllers.Select(x => x.Id).ToList();
                    await _repository.DeleteAsync(x => ids.Contains(x.Id));
                }
                await _repository.SaveAsync();
            }
        }
    }
}

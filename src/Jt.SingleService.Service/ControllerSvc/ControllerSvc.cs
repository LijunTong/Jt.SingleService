using Jt.SingleService.Core.Attributes;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Lib.Utils;
using Jt.SingleService.Data.Repositories.Interface;
using Jt.SingleService.Service.ControllerSvc;
using System.Reflection;
using Jt.SingleService.Lib.DI;

namespace Jt.SingleService.Service.UserSvc
{
    public class ControllerSvc : BaseSvc<Controller>, IControllerSvc, ITransientInterface
    {
        private readonly IControllerRepo _repository;
        private readonly CHelperSnowflake _snowflake;

        public ControllerSvc(IControllerRepo repository, CHelperSnowflake snowflake) : base(repository)
        {
            _repository = repository;
            _snowflake = snowflake;
        }

        public async Task<List<Controller>> GetControllersAsync()
        {
            return await _repository.GetListAsync();
        }

        public async Task InitControllerAsync()
        {
            Assembly[] assembly = AppDomain.CurrentDomain.GetAssemblies();
            var types = CHelperAssembly.GetTypesByAttribute(assembly, typeof(AuthorControllerAttribute));
            if (types != null)
            {
                var existsControllers = await GetAllListAsync();

                List<Controller> addControllers = new List<Controller>();
                foreach (var item in types)
                {
                    if(!existsControllers.Any(x=>x.Name == item.Name))
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
                    if(!types.Any(x=>x.Name == item.Name))
                    {
                        delControllers.Add(item);
                    }
                }
                if(addControllers.Any())
                {
                    await _repository.InsertListAsync(addControllers);
                }
                if(delControllers.Any())
                {
                    await _repository.DeleteAsync(x => delControllers.Where(o => o.Id == x.Id).Count() > 0);
                }
                await _repository.SaveAsync();
            }
        }
    }
}

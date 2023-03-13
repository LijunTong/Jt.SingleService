using Jt.SingleService.Core.Attributes;
using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Core.Utils;
using Jt.SingleService.Service.ControllerSvc;
using System.Reflection;

namespace Jt.SingleService.Service.UserSvc
{
    public class ControllerSvc : BaseSvc<Controller>, IControllerSvc, ITransientInterface
    {
        private readonly IControllerRepo _repository;

        public ControllerSvc(IControllerRepo repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<Controller>> GetControllersAsync()
        {
            return await _repository.GetListAsync();
        }

        public async Task InitControllerAsync()
        {
            Assembly assembly = Assembly.LoadFrom(CHelperAppDomain.CombineWithBaseDirectory("Jt.SingleService.dll"));
            var types = CHelperAssembly.GetTypesByAttribute(assembly, typeof(AuthorControllerAttribute));
            if (types != null)
            {
                List<Controller> controllers = new List<Controller>();
                foreach (var item in types)
                {
                    controllers.Add(new Controller { Name = item.Name, CreateTime = DateTime.Now, Creater = "", UpTime = DateTime.Now, Updater = "" });
                }
                await _repository.InsertListAsync(controllers);
            }

            await _repository.SaveAsync();
        }
    }
}

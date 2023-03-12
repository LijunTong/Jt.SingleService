using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.ControllerSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class ControllerSvc : BaseSvc<Controller>, IControllerSvc
    {
        private readonly IControllerRepo _repository;

        public ControllerSvc(IControllerRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

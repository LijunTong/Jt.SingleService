using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.ActionSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class ActionSvc : BaseSvc<Core.Tables.Action>, IActionSvc
    {
        private readonly IActionRepo _repository;

        public ActionSvc(IActionRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

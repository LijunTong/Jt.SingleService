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

        public Task<List<Core.Tables.Action>> GetActionsAsync(string controller)
        {
            throw new NotImplementedException();
        }

        public Task InitActionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task LoadActionsRedisAsync()
        {
            throw new NotImplementedException();
        }
    }
}

using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.ActionSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class ActionSvc : BaseSvc<Core.Tables.Action>, IActionSvc, ITransientInterface
    {
        private readonly IActionRepo _repository;

        public ActionSvc(IActionRepo repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<List<Core.Tables.Action>> GetActionsAsync(string controller)
        {
            return await _repository.GetListAsync(x => x.Controller == controller);
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

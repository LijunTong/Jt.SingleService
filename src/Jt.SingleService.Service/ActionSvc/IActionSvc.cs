using Jt.SingleService.Data.Tables;
using Action = Jt.SingleService.Data.Tables.Action;

namespace Jt.SingleService.Service.ActionSvc
{
    public interface IActionSvc : IBaseSvc<Action>
    {
        Task InitActionsAsync();

        Task<List<Action>> GetActionsAsync(string controller);

        Task LoadActionsRedisAsync();
    }
}
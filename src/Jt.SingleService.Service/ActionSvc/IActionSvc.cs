using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Service.ActionSvc
{
    public interface IActionSvc : IBaseSvc<Core.Tables.Action>
    {
        Task InitActionsAsync();

        Task<List<Core.Tables.Action>> GetActionsAsync(string controller);

        Task LoadActionsRedisAsync();
    }
}
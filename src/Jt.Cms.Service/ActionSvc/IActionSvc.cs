using Jt.Cms.Data.Tables;
using Action = Jt.Cms.Data.Tables.Action;

namespace Jt.Cms.Service.ActionSvc
{
    public interface IActionSvc : IBaseSvc<Action>
    {
        Task InitActionsAsync();

        Task<List<Action>> GetActionsAsync(string controller);

        Task LoadActionsRedisAsync();
    }
}
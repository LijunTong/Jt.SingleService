using Jt.Cms.Core;
using Action = Jt.Cms.Data.Action;
namespace Jt.Cms.Service
{
    public interface IActionSvc : IBaseSvc<Action>
    {
        Task InitActionsAsync();

        Task<ApiResponse<List<Action>>> GetActionsAsync(string controller);

        Task LoadActionsRedisAsync();
    }
}
using Jt.SingleService.Core;
using Action = Jt.SingleService.Data.Action;
namespace Jt.SingleService.Service
{
    public interface IActionSvc : IBaseSvc<Action>
    {
        Task InitActionsAsync();

        Task<ApiResponse<List<Action>>> GetActionsAsync(string controller);

        Task LoadActionsRedisAsync();
    }
}
using Jt.SingleService.Core;
using Jt.SingleService.Data;
namespace Jt.SingleService.Service
{
    public interface IControllerSvc : IBaseSvc<Controller>
    {
        Task InitControllerAsync();

        Task<ApiResponse<List<Controller>>> GetControllersAsync();
    }
}
using Jt.Cms.Core;
using Jt.Cms.Data;
namespace Jt.Cms.Service
{
    public interface IControllerSvc : IBaseSvc<Controller>
    {
        Task InitControllerAsync();

        Task<ApiResponse<List<Controller>>> GetControllersAsync();
    }
}
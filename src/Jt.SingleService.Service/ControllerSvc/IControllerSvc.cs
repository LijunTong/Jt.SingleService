using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Service.ControllerSvc
{
    public interface IControllerSvc : IBaseSvc<Controller>
    {
        Task InitControllerAsync();

        Task<List<Controller>> GetControllersAsync();
    }
}
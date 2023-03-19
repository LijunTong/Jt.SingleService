using Jt.SingleService.Data.Tables;

namespace Jt.SingleService.Service.ControllerSvc
{
    public interface IControllerSvc : IBaseSvc<Controller>
    {
        Task InitControllerAsync();

        Task<List<Controller>> GetControllersAsync();
    }
}
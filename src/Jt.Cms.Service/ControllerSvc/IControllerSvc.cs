using Jt.Cms.Data.Tables;

namespace Jt.Cms.Service.ControllerSvc
{
    public interface IControllerSvc : IBaseSvc<Controller>
    {
        Task InitControllerAsync();

        Task<List<Controller>> GetControllersAsync();
    }
}
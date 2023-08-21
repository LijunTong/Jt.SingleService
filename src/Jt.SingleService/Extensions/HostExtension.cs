using Jt.SingleService.Service;

namespace Jt.SingleService.Extensions
{
    public static class HostExtension
    {
        public static async Task<IHost> InitControllerAsync(this IHost host)
        {
            var controllerService = (IControllerSvc)host.Services.CreateScope().ServiceProvider.GetService(typeof(IControllerSvc));
            await controllerService.InitControllerAsync();
            var actionService = (IActionSvc)host.Services.CreateScope().ServiceProvider.GetService(typeof(IActionSvc));
            await actionService.InitActionsAsync();
            return host;
        }

        public static async Task<IHost> InitRoleActionAsync(this IHost host)
        {
            var roleActionService = (IRoleActionSvc)host.Services.GetService(typeof(IRoleActionSvc));
            await roleActionService.LoadRoleActionsRedisAsync();
            var actionService = (IActionSvc)host.Services.GetService(typeof(IActionSvc));
            await actionService.LoadActionsRedisAsync();
            return host;
        }


    }
}

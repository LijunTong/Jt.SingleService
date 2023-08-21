using Jt.SingleService.Core;
using Jt.SingleService.Data;
using Jt.Common.Tool.DI;
using Jt.SingleService.Service;
using Microsoft.AspNetCore.Authorization;

namespace Jt.SingleService
{
    public class AuthorizeHandler : AuthorizationHandler<PolicyRequirement>, IAuthorizationHandler, ITransientDIInterface
    {
        private readonly JwtHelper _jwtHelper;
        private readonly IActionSvc _actionSvc;
        private readonly IRoleActionRepo _roleActionRepo;

        public AuthorizeHandler(JwtHelper jwtHelper, IActionSvc actionSvc, IRoleActionRepo roleActionRepo)
        {
            _jwtHelper = jwtHelper;
            _actionSvc = actionSvc;
            _roleActionRepo = roleActionRepo;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PolicyRequirement requirement)
        {
            var isAuthenticated = context.User.Identity.IsAuthenticated; //是否经过验证
            if (isAuthenticated)
            {
                var http = (context.Resource as Microsoft.AspNetCore.Http.DefaultHttpContext);
                string id = context.User.Claims.FirstOrDefault(x => x.Type == "Id")?.Value;
                string[] role = context.User.Claims.FirstOrDefault(x => x.Type == "Roles")?.Value.Split(",");
                if (role != null && role.Length > 0)
                {
                    if (role.Contains("1"))
                    {
                        context.Succeed(requirement);
                        return;
                    }

                    var action = await _actionSvc.GetEntityAsync(x => ("/" + x.Controller.Replace("Controller", "") + "/" + x.Name).ToLower() == http.Request.Path.ToString().ToLower());
                    if (action == null)
                    {
                        //如果没设置鉴权标志，则表示不用鉴权
                        context.Succeed(requirement);
                        return;
                    }

                    var roleActions = await _roleActionRepo.GetListAsync(x => role.Contains(x.RoleId) && ("/" + x.Controller.Replace("Controller", "") + "/" + x.Action).ToLower() == http.Request.Path.ToString().ToLower());
                    if (roleActions != null && roleActions.Count > 0)
                    {
                        context.Succeed(requirement);
                        return;
                    }
                }
            }
            await Task.CompletedTask;
        }
    }
}

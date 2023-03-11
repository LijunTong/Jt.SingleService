using Jt.SingleService.Core.DI;
using Microsoft.AspNetCore.Authorization;

namespace Jt.SingleService.Core.Jwt
{
    public class AuthorizeHandler : AuthorizationHandler<PolicyRequirement>, IAuthorizationHandler, ITransientInterface
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PolicyRequirement requirement)
        {
            var isAuthenticated = context.User.Identity.IsAuthenticated; //是否经过验证
            if (isAuthenticated)
            {
                var http = (context.Resource as Microsoft.AspNetCore.Http.DefaultHttpContext);

                var questUrl = http.Request.Path.ToString().ToLower();

                if (questUrl != "/User/GetInfo".ToLower())
                {
                    context.Succeed(requirement);
                }
            }
            await Task.CompletedTask;
        }
    }
}

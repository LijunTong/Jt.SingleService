using Jt.Cms.Core;
using Microsoft.Extensions.Options;

namespace Jt.Cms
{
    public class RequestCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestCheckMiddleware> _logger;
        private readonly AppSettings _appSettings;

        public RequestCheckMiddleware(RequestDelegate next,
                                    ILogger<RequestCheckMiddleware> logger,
                                    IOptionsMonitor<AppSettings> setting)
        {
            _next = next;
            _logger = logger;
            _appSettings = setting.CurrentValue;
        }

        public async Task Invoke(HttpContext context)
        {
            var req = context.Request;
            if (!req.Headers["app"].Contains(_appSettings.AppName))
            {
                string error = "非法请求";
                await context.Response.WriteAsync(error);
                return;
            }
            await _next(context);
        }
    }

    public static class RequestCheckExtension
    {
        public static IApplicationBuilder UseRequestCheck(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestCheckMiddleware>();
        }
    }
}

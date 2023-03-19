using Jt.Cms.Lib.Extensions;
using Jt.Cms.Core.Models;
using Jt.Cms.Core.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Jt.Cms.Core.Middlewares
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

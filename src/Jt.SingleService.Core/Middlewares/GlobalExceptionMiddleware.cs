using Jt.SingleService.Core.Extensions;
using Jt.SingleService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace Jt.SingleService.Core.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "捕获全局异常");
                var result = ApiResponse<string>.GetFail(ApiReturnCode.SystemError, "请求异常");
                httpContext.Response.StatusCode = 200;
                httpContext.Response.ContentType = "text/json;charset=utf-8;";
                string error = result.ToJosn();
                await httpContext.Response.WriteAsync(error);
            }
        }
    }
}

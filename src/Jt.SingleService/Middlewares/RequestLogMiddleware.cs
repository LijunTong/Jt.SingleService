using Jt.SingleService.Core;
using Jt.Common.Tool.Extension;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Text;

namespace Jt.SingleService
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLogMiddleware> _logger;
        private readonly AppSettings _appSettings;

        public RequestLogMiddleware(RequestDelegate next,
                                    ILogger<RequestLogMiddleware> logger,
                                    IOptionsMonitor<AppSettings> setting)
        {
            _next = next;
            _logger = logger;
            _appSettings = setting.CurrentValue;
        }

        public async Task Invoke(HttpContext context)
        {
            var req = context.Request;
            if (req.Headers["x-requested-with"] != "XMLHttpRequest")
            {
                await _next(context);
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var log = new RequestResponseLog
            {
                Url = req.Path.ToString(),
                Headers = req.Headers.ToDictionary(k => k.Key, v => string.Join(";", v.Value.ToList())),
                Method = req.Method,
                QueryString = req.QueryString.Value
            };

            if (req.ContentLength != null && req.ContentLength.Value > 0)
            {
                req.EnableBuffering(); // 启用重复读取body
                byte[] buffer = new byte[req.ContentLength.Value];
                await req.BodyReader.AsStream().ReadAsync(buffer, 0, buffer.Length);
                req.Body.Seek(0, SeekOrigin.Begin); // 将指针指向起始位置
                log.RequestBody = Encoding.UTF8.GetString(buffer);
            }

            {
                var response = context.Response;
                var originalBodyStream = response.Body;
                using (var responseBody = new MemoryStream())
                {
                    response.Body = responseBody;
                    await _next(context);
                    response.Body.Seek(0, SeekOrigin.Begin);
                    var body = await new StreamReader(response.Body).ReadToEndAsync();
                    response.Body.Seek(0, SeekOrigin.Begin);
                    if (response.ContentType != null && response.ContentType.Contains("application/json"))
                    {
                        log.ResponseBody = body;
                    }
                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }

            stopwatch.Stop();
            log.ExcuteTime = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation(log.ToJson());
        }
    }

    public static class RequestLogExtension
    {
        public static IApplicationBuilder UseRequestLog(this IApplicationBuilder app)
        {
            return app.UseMiddleware<RequestLogMiddleware>();
        }
    }
}

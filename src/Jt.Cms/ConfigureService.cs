using Jt.Cms.Core;
using Jt.Cms.Extensions;
using Jt.Common.Tool.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using NLog.Web;
using System.Net.Mime;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Jt.Cms
{
    public class ConfigureService
    {
        public static void AddServices(WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var env = builder.Environment;
            builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            builder.Configuration.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);

            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(LogLevel.Trace);
            builder.Logging.AddNLog("NLog.config");
            builder.Host.UseNLog();

            var config = builder.Configuration.GetSection(AppSettings.Position);
            var appSetting = config.Get<AppSettings>();

            services.AddJsonSerializerOptions(options =>
            {
                options.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                options.WriteIndented = true;
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.AllowTrailingCommas = true;
                options.PropertyNameCaseInsensitive = true;
                options.Converters.Add(new DateTimeJsonConverter());
            });

            services.AddControllers(e =>
            {
                e.Filters.Add<ExceptionFilterAttribute>();
                e.Filters.Add<LogActionFilterAttribute>();
            }).ConfigureApiBehaviorOptions(options =>
            {
                // 自定义模型校验返回
                options.InvalidModelStateResponseFactory = context =>
                {
                    // 创建项目定义的统一的返回结构ApiResponse<object>

                    string error = "";
                    foreach (var item in context.ModelState)
                    {
                        error = item.Value?.Errors[0]?.ErrorMessage;
                        break;
                    }
                    if (error.IsNullOrWhiteSpace())
                    {
                        error = "请求参数有误";
                    }
                    var apiResult = ApiResponse<object>.ParamError(error);
                    var result = new ObjectResult(apiResult);
                    result.StatusCode = StatusCodes.Status200OK;
                    result.ContentTypes.Add(MediaTypeNames.Application.Json);
                    return result;
                };

            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });

            services.AddSwaggerGen(appSetting);

            services.AddAuthentication(appSetting);
            services.AddAuthorization("Default");

            services.AddCustomService(config);

            services.AddMysql();

            //解决跨域问题，添加允许访问的域
            services.AddCors("Domain");

            services.AddQuartz(appSetting);
        }

        public static async void Use(WebApplication app)
        {
            var appSetting = app.Configuration.GetSection("AppSettings").Get<AppSettings>();

            app.UseStatusCodePages();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files")),
                OnPrepareResponse = (c) =>
                {
                    c.Context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                },
                RequestPath = "/Files"
            });

            app.UseGlobalException();
            app.UseRequestLog();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{appSetting.AppVersion}/swagger.json", $"{appSetting.AppName} {appSetting.AppVersion}");
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("Domain");//解决跨域问题，必须在UseRouting()和UseEndpoints()之间

            try
            {
                await app.InitControllerAsync();
            }
            catch (Exception ex)
            {
                app.Logger.LogError(ex, $"Init Exception:{ex.Message}");
            }

            app.MapDefaultControllerRoute();
        }

        public static void Run(WebApplication app)
        {
            app.Logger.LogInformation($"Application Running! Env: {app.Environment.EnvironmentName}!");

            app.Run();
        }
    }
}

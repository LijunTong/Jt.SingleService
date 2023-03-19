using Jt.Cms.Lib.Extensions;
using Jt.Cms.Core.Filters;
using Jt.Cms.Core.Middlewares;
using Jt.Cms.Core.Options;
using Jt.Cms.Extensions;
using LogDashboard;
using Microsoft.Extensions.Options;
using NLog.Web;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.Extensions.FileProviders;

namespace Jt.Cms
{
    public class StartUp
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
            }).AddJsonOptions(option =>
            {
                option.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                option.JsonSerializerOptions.WriteIndented = true;
                option.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                option.JsonSerializerOptions.AllowTrailingCommas = true;
                option.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                option.JsonSerializerOptions.Converters.Add(new DateTimeJsonConverter());
            });

            services.AddSwaggerGen(appSetting);

                                                                                                                                                                           

            services.AddLogDashboard();

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

            app.UseLogDashboard();

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

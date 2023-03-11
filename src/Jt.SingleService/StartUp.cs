using Jt.SingleService.Core.Extensions;
using Jt.SingleService.Core.Middlewares;
using Jt.SingleService.Core.Options;
using LogDashboard;
using NLog.Web;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Jt.SingleService
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

            services.AddControllers();

            services.AddSwaggerGen(appSetting);

            services.AddJsonSerializerOptions(options =>
            {
                options.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                options.WriteIndented = true;
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.AllowTrailingCommas = true;
                options.PropertyNameCaseInsensitive = true;
            });

            services.AddLogDashboard();

            services.AddAuthentication(appSetting);
            services.AddAuthorization("Default");

            services.AddCustomService(config);
        }

        public static void Use(WebApplication app)
        {
            var appSetting = app.Configuration.GetSection("AppSettings").Get<AppSettings>();

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

            app.MapDefaultControllerRoute();
        }

        public static void Run(WebApplication app)
        {
            app.Logger.LogInformation($"Application Running! Env: {app.Environment.EnvironmentName}!");

            app.Run();
        }
    }
}

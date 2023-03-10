using Jt.SingleService.Core.Extensions;
using Jt.SingleService.Core.Options;
using Serilog;
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
            builder.Host.UseSerilog(Log.Logger, dispose: true);

            var appSetting = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();

            services.AddControllers();

            services.AddSwaggerGen(appSetting.AppName, appSetting.AppVersion);

            services.AddCustomService();

            services.AddJsonSerializerOptions(options =>
            {
                options.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                options.WriteIndented = true;
                options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.AllowTrailingCommas = true;
                options.PropertyNameCaseInsensitive = true;
            });
        }

        public static void Use(WebApplication app)
        {
            var appSetting = app.Configuration.GetSection("AppSettings").Get<AppSettings>();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{appSetting.AppVersion}/swagger.json", $"{appSetting.AppName} {appSetting.AppVersion}");
            });

            app.MapDefaultControllerRoute();
        }

        public static void Run(WebApplication app)
        {
            app.Run();
        }
    }
}

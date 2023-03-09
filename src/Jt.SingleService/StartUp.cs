using Jt.SingleService.Core.Cache;
using Jt.SingleService.Core.Extensions;
using Jt.SingleService.Core.Options;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Data.Repositories;
using Jt.SingleService.Service.UserSvc;
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

            var appSetting = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();

            services.AddControllers();

            services.AddSwaggerGen(appSetting.AppName, appSetting.AppVersion);

            // jsonOptions
            var jsonOptions = new JsonSerializerOptions();
            jsonOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            jsonOptions.WriteIndented = true;
            jsonOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            jsonOptions.AllowTrailingCommas = true;
            jsonOptions.PropertyNameCaseInsensitive = true;
            services.AddSingleton(jsonOptions);

            services.AddSingleton<ICacheService, RedisCacheService>();
            services.AddSingleton<IUserRepo, UserRepo>();
            services.AddSingleton<IUserSvc, UserSvc>();

        }

        public static void Use(WebApplication app)
        {
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
            });

            app.MapDefaultControllerRoute();
        }

        public static void Run(WebApplication app)
        {
            app.Run();
        }
    }
}

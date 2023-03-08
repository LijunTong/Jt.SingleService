using Jt.SingleService.Core.Cache;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Jt.SingleService
{
    public class StartUp
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddControllers();



            // jsonOptions
            var jsonOptions = new JsonSerializerOptions();
            jsonOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            jsonOptions.WriteIndented = true;
            jsonOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            jsonOptions.AllowTrailingCommas = true;
            jsonOptions.PropertyNameCaseInsensitive = true;
            services.AddSingleton(jsonOptions);

            services.AddSingleton<ICacheService, RedisCacheService>();

        }

        public static void Use(WebApplication app)
        {
            app.UseAuthorization();

            app.MapControllers();
        }

        public static void Run(WebApplication app)
        {
            app.Run();
        }
    }
}

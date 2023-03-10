using Jt.SingleService.Core.DI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text.Json;

namespace Jt.SingleService.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 服务接口注入
        /// </summary>
        /// <param name="services">services</param>
        /// <returns>IServiceCollection</returns>
        public static IServiceCollection AddCustomService(this IServiceCollection services)
        {
            services.RegisterLifetimesByInhreit(typeof(IScopedInterface));
            services.RegisterLifetimesByInhreit(typeof(ITransientInterface));
            services.RegisterLifetimesByInhreit(typeof(ISingletonInterface));
            return services;
        }

        private static void RegisterLifetimesByInhreit(this IServiceCollection services, Type lifetimeType)
        {
            List<Type> types = AppDomain.CurrentDomain
                                .GetAssemblies()
                                .SelectMany(x => x.GetTypes())
                                .Where(x => lifetimeType.IsAssignableFrom(x) && x.IsClass && !x.IsAbstract)
                                .ToList();
            foreach (Type type in types)
            {
                var interfaces = type.GetInterfaces().ToList();
                foreach (var item in interfaces)
                {
                    if (item == lifetimeType)
                    {
                        continue;
                    }

                    if (lifetimeType == typeof(ISingletonInterface))
                    {
                        services.AddSingleton(item, type);
                    }
                    else if (lifetimeType == typeof(IScopedInterface))
                    {
                        services.AddScoped(item, type);
                    }
                    else if (lifetimeType == typeof(ITransientInterface))
                    {
                        services.AddTransient(item, type);
                    }
                }
            }
        }

        public static IServiceCollection AddSwaggerGen(this IServiceCollection services, string title, string version)
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            // 添加Swagger 
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new OpenApiInfo { Title = title, Version = version });
                // c.IncludeXmlComments(xmlPath);
                //开启权限小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                // 在header添加token
                c.OperationFilter<SecurityRequirementsOperationFilter>();
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization", // jwt默认的参数名称
                    Type = SecuritySchemeType.ApiKey,
                    In = ParameterLocation.Header
                });
            });
        }

        public static IServiceCollection AddJsonSerializerOptions(this IServiceCollection services, Action<JsonSerializerOptions> options)
        {
            services.ConfigureJsonSerializerOptions(options);
            return services;
        }

        private static void ConfigureJsonSerializerOptions(this IServiceCollection services, Action<JsonSerializerOptions> options)
        {
            services.Configure(options);
        }
    }
}

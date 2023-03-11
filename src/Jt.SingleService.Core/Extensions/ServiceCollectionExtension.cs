using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Jwt;
using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Options;
using Jt.SingleService.Core.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
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
        public static IServiceCollection AddCustomService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettings>(configuration);
            services.RegisterLifetimesByInhreit(typeof(IScopedInterface));
            services.RegisterLifetimesByInhreit(typeof(ITransientInterface));
            services.RegisterLifetimesByInhreit(typeof(ISingletonInterface));
            services.AddTransient<IAuthorizationHandler, AuthorizeHandler>();
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
                var interfaces = type.GetInterfaces().Where(x=> x != lifetimeType ).ToList();
                if (interfaces.Count > 0)
                {
                    foreach (var item in interfaces)
                    {
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
                else
                {
                    if (lifetimeType == typeof(ISingletonInterface))
                    {
                        services.AddSingleton(type);
                    }
                    else if (lifetimeType == typeof(IScopedInterface))
                    {
                        services.AddScoped(type);
                    }
                    else if (lifetimeType == typeof(ITransientInterface))
                    {
                        services.AddTransient(type);
                    }
                }
            }
        }

        public static IServiceCollection AddSwaggerGen(this IServiceCollection services, AppSettings appSettings)
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            // 添加Swagger 
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(appSettings.AppVersion, new OpenApiInfo { Title = appSettings.AppName, Version = appSettings.AppVersion });
                // c.IncludeXmlComments(xmlPath);
                //开启权限小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                c.OperationFilter<AddHeaderFiler>();
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
            return services.ConfigureJsonSerializerOptions(options);
        }

        private static IServiceCollection ConfigureJsonSerializerOptions(this IServiceCollection services, Action<JsonSerializerOptions> options)
        {
            return services.Configure(options);
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddTransient(typeof(JwtSecurityTokenHandler));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(o =>
                    {
                        o.RequireHttpsMetadata = false;
                        o.TokenValidationParameters = new TokenValidationParameters
                        {
                            // 验证发布者
                            ValidateIssuer = true,
                            ValidIssuer = appSettings.Jwt.Issuer,

                            // 验证接收者
                            ValidateAudience = true,
                            ValidAudience = appSettings.Jwt.Audience,

                            // 验证过期
                            ValidateLifetime = true,

                            // 验证私钥
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Jwt.SecurityKey)),
                        };
                        o.Events = new JwtBearerEvents
                        {
                            //权限验证失败后执行
                            OnChallenge = async context =>
                            {
                                context.HandleResponse();
                                var result = ApiResponse<string>.GetFail(ApiReturnCode.UnAuth, "令牌过期").ToJosn();
                                context.Response.ContentType = "application/json";
                                context.Response.Headers.Add("Access-Control-Allow-Origin", "*"); //解决跨域，因为没走管道
                                context.Response.StatusCode = StatusCodes.Status200OK;
                                await context.Response.WriteAsync(result);
                            },
                            OnForbidden = async context =>
                            {
                                var result = ApiResponse<string>.GetFail(ApiReturnCode.Forbidden, "没有权限").ToJosn();
                                context.Response.ContentType = "application/json";
                                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");//解决跨域，因为没走管道
                                context.Response.StatusCode = StatusCodes.Status200OK;
                                await context.Response.WriteAsync(result);
                            },
                        };
                    });
            return services;
        }

        public static IServiceCollection AddAuthorization(this IServiceCollection services, string name)
        {
            return services.AddAuthorization(x =>
            {
                x.AddPolicy(name, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.AddRequirements(new PolicyRequirement());
                });
            });
        }
    }
}

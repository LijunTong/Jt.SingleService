using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Common.Tool.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quartz;
using Swashbuckle.AspNetCore.Filters;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Jt.Cms.Extensions
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

            services.AddServiceByJtDIInterface();

            return services;
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
                                var result = ApiResponse<object>.Fail(ApiReturnCode.UnAuth, "令牌过期").ToJson();
                                context.Response.ContentType = "application/json";
                                context.Response.Headers.Add("Access-Control-Allow-Origin", "*"); //解决跨域，因为没走管道
                                context.Response.StatusCode = StatusCodes.Status200OK;
                                await context.Response.WriteAsync(result);
                            },
                            OnForbidden = async context =>
                            {
                                var result = ApiResponse<object>.Fail(ApiReturnCode.Forbidden, "没有权限").ToJson();
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

        public static IServiceCollection AddMysql(this IServiceCollection services)
        {
            services.AddScoped<MysqlDbContext>();

            return services;
        }

        public static IServiceCollection AddCors(this IServiceCollection services, string name)
        {
            return services.AddCors(options =>
            {
                options.AddPolicy(name, builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void AddQuartz(this IServiceCollection services, AppSettings appSettings)
        {
            // Add the required Quartz.NET services
            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();
                if (appSettings.Quartz != null)
                {
                    foreach (var job in appSettings.Quartz.Jobs)
                    {
                        if (job.Enable)
                        {
                            var jobKey = new JobKey(job.JobName);
                            string[] typeInfo = job.Type.Split(',');
                            Assembly assembly = Assembly.Load(typeInfo[1]);
                            Type type = assembly.GetType(typeInfo[0]);
                            q.AddJob(type, jobKey);
                            q.AddTrigger(opt => opt
                                .ForJob(jobKey)
                                .WithIdentity($"{job.JobName}.Trigger")
                                .WithCronSchedule(job.Cron)
                            );
                        }
                    }
                }
            });

            // Add the Quartz.NET hosted service
            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        }
    }
}

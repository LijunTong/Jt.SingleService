using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Extensions
{
    public class ServiceCollectionExtension
    {
        public static IServiceCollection AddSwaggerGen(this IServiceCollection services, string title, string version, string xmlPath)
        {
            return // 添加Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(version, new OpenApiInfo { Title = title, Version = version });
                c.IncludeXmlComments(xmlPath);
                //开启权限小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                //在header添加token
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
    }
}

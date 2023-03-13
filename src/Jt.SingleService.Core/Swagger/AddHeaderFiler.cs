using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Swagger
{
    public class AddHeaderFiler : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "x-requested-with",
                In = ParameterLocation.Header,
                Schema = new OpenApiSchema
                {
                    Type = "string",
                    Default = new OpenApiString("XMLHttpRequest")
                }
            });
        }
    }
}

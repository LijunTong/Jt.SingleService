using Jt.SingleService.Core.Enums;
using Jt.SingleService.Core.Extensions;
using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Tables;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace Jt.SingleService.Core.Filters
{
    public class ExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        private ILogger<ExceptionFilterAttribute> _logger;

        //构造注入日志组件
        public ExceptionFilterAttribute(ILogger<ExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled)//异常已被捕获，不处理
            {
                return;
            }
            if (context.Exception is ValidationException)
            {
                //Model数据校验失败，返回200
                var result = ApiResponse<bool>.GetFail(ApiReturnCode.SystemError, context.Exception.Message);
                context.Result = new JsonResult(result);
            }
            else
            {
                try
                {
                    string msg = $"{context.HttpContext.Request.Path} {context.HttpContext.Request.Method}";
                    var caDes = context.ActionDescriptor as ControllerActionDescriptor;
                    string param = "";
                    foreach (var item in context.ActionDescriptor.Parameters)
                    {
                        param += $"{item.Name},{item.ParameterType};";
                    }
                    SysLog sysLog = new SysLog
                    {
                        Type = (int)EnumLogType.ErrLog,
                        Title = context.Exception.Message,
                        Content = $"{msg}",
                        LogTime = DateTime.Now,
                        UserId = "",
                        Controller = caDes.ControllerName,
                        Action = caDes.ActionName,
                        Param = param
                    };
                    _logger.LogError(context.Exception, sysLog.ToJosn());
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "日志记录出错", ex.Message);
                }

                context.ExceptionHandled = true;

                var result = ApiResponse<bool>.GetFail(ApiReturnCode.SystemError, "请求异常");
                context.Result = new JsonResult(result);
            }
        }
    }
}

using Jt.SingleService.Core;
using Jt.SingleService.Data;
using Jt.SingleService.Service;
using Jt.Common.Tool.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.ComponentModel.DataAnnotations;

namespace Jt.SingleService
{
    public class ExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        private ILogger<ExceptionFilterAttribute> _logger;
        private ISysLogCacheSvc _sysLogCacheSvc;
        private JwtHelper _jwtHelper;
        private readonly IIDSvc _snowflake;

        //构造注入日志组件
        public ExceptionFilterAttribute(ILogger<ExceptionFilterAttribute> logger, JwtHelper jwtHelper, ISysLogCacheSvc sysLogCacheSvc, IIDSvc snowflake)
        {
            _logger = logger;
            _jwtHelper = jwtHelper;
            _sysLogCacheSvc = sysLogCacheSvc;
            _snowflake = snowflake;
        }

        public async void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled)//异常已被捕获，不处理
            {
                return;
            }
            if (context.Exception is ValidationException)
            {
                //Model数据校验失败，返回200
                var result = ApiResponse<object>.Fail(ApiReturnCode.SystemError, context.Exception.Message);
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

                    string userId = "";
                    var user = _jwtHelper.User<JwtUser>(context.HttpContext.Request);
                    if (user != null)
                    {
                        userId = user.Id;
                    }
                    string address = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                    SysLog sysLog = new SysLog
                    {
                        Id = _snowflake.NextId().ToString(),
                        Type = (int)EnumLogType.ErrLog,
                        Title = msg,
                        Content = context.Exception.Message,
                        LogTime = DateTime.Now,
                        UserId = userId,
                        Controller = caDes.ControllerName,
                        Action = caDes.ActionName,
                        RemoteAddress = address,
                        Param = param,
                        CreateTime = DateTime.Now,
                        Creater = "LogAction",
                        UpTime = DateTime.Now,
                        Updater = "LogAction"
                    };
                    await _sysLogCacheSvc.PushLogAsync(sysLog);
                    _logger.LogError(context.Exception, sysLog.ToJson());
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "日志记录出错", ex.Message);
                }

                context.ExceptionHandled = true;

                var result = ApiResponse<object>.Fail(ApiReturnCode.SystemError, "请求异常");
                context.Result = new JsonResult(result);
            }
        }
    }
}

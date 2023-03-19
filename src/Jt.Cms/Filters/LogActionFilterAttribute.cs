using Jt.Cms.Core.Attributes;
using Jt.Cms.Core.Enums;
using Jt.Cms.Core.Jwt;
using Jt.Cms.Data.Tables;
using Jt.Cms.Lib.Utils;
using Jt.Cms.Service.UserSvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Jt.Cms.Core.Filters
{
    public class LogActionFilterAttribute : Attribute, IActionFilter
    {
        private ILogger<LogActionFilterAttribute> _logger;
        private ISysLogCacheSvc _sysLogCacheSvc;
        private JwtHelper _jwtHelper;
        private readonly CHelperSnowflake _snowflake;

        public LogActionFilterAttribute(ILogger<LogActionFilterAttribute> logger, ISysLogCacheSvc sysLogCacheService, JwtHelper jwtService, CHelperSnowflake snowflake)
        {
            _logger = logger;
            _sysLogCacheSvc = sysLogCacheService;
            _jwtHelper = jwtService;
            _snowflake = snowflake;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            try
            {
                string msg = $"{context.HttpContext.Request.Path} {context.HttpContext.Request.Method}";
                var caDes = context.ActionDescriptor as ControllerActionDescriptor;
                var attr = caDes.MethodInfo.GetCustomAttributes(typeof(ActionAttribute), true).FirstOrDefault() as ActionAttribute;
                if (attr == null || attr.ActionType == EnumActionType.Authorize)
                {
                    return;
                }
                string address = context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                //记录日志
                string param = CHelperJson.SerializeObject(context.ActionArguments);
                if (param.Length > 2000)
                {
                    param = param.Substring(0, 2000);
                }
                string userId = "";
                var user = await _jwtHelper.UserAsync<JwtUser>(context.HttpContext.Request);
                if (user != null)
                {
                    userId = user.Id;
                }
                SysLog sysLog = new SysLog
                {
                    Id = _snowflake.NextId().ToString(),
                    Type = (int)EnumLogType.OpLog,
                    Title = $"{attr.Text}",
                    Content = $"{msg}",
                    LogTime = DateTime.Now,
                    UserId = userId,
                    RemoteAddress = address,
                    Controller = caDes.ControllerName,
                    Action = caDes.ActionName,
                    Param = param,
                    CreateTime = DateTime.Now,
                    Creater = "LogAction",
                    UpTime = DateTime.Now,
                    Updater = "LogAction"
                };
                await _sysLogCacheSvc.PushLogAsync(sysLog);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("日志记录出错", ex.Message);
            }
        }
    }
}

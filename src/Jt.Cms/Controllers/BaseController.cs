using Jt.Cms.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jt.Cms.Controllers
{
    [ApiController]
    [Authorize("Default")]
    public class BaseController : ControllerBase
    {
        [NonAction]
        protected string GetToken()
        {
            string authorization = HttpContext.Request.Headers["Authorization"];
            if(authorization != null)
            {
                string token = authorization.Replace(JwtBearerDefaults.AuthenticationScheme, "").Replace(" ", "");
                return token;
            }
            return null;
        }

        protected ActionResult Successed<T>(T t)
        {
            return Ok(ApiResponse<T>.GetSucceed(t));
        }

        protected ActionResult Fail(string msg)
        {
            return Ok(ApiResponse<string>.GetFail(ApiReturnCode.OperationFail, msg));
        }
    }
}

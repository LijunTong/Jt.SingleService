using Jt.Cms.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jt.Cms.Controllers
{
    [ApiController]
    [Authorize("Default")]
    public class BaseController : ControllerBase
    {
        protected readonly JwtHelper _jwtHelper;

        public BaseController(JwtHelper jwtHelper)
        {
            _jwtHelper = jwtHelper;
        }

        [NonAction]
        protected string GetToken()
        {
            string authorization = HttpContext.Request.Headers["Authorization"];
            if (authorization != null)
            {
                string token = authorization.Replace(JwtBearerDefaults.AuthenticationScheme, "").Replace(" ", "");
                return token;
            }
            return null;
        }

        [NonAction]
        protected JwtUser GetUser()
        {
            return _jwtHelper.User<JwtUser>(GetToken());
        }

        protected ActionResult Successed<T>(T t)
        {
            return Ok(ApiResponse<object>.Succeed(t));
        }

        protected ActionResult Fail(string msg)
        {
            return Ok(ApiResponse<object>.Fail(ApiReturnCode.OperationFail, msg));
        }
    }
}

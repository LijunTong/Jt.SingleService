using Jt.SingleService.Core.Extensions;
using Jt.SingleService.Core.Jwt;
using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.UserSvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Jt.SingleService.Controllers
{
    [Route("User")]
    public class UserController : BaseController
    {
        private readonly IUserSvc _userSvc;
        private readonly JwtHelper _jwtHelper;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserSvc userSvc,
                              JwtHelper jwtHelper,
                              ILogger<UserController> logger)
        {
            _userSvc = userSvc;
            _jwtHelper = jwtHelper;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult> Login([FromBody] User user)
        {
            _logger.LogInformation("Login：{user}", user.ToJosn());
            if (user != null)
            {
                string token = await _jwtHelper.TokenAsync(user);
                return Ok(ApiResponse<string>.GetSucceed(token));
            }
            return Ok(ApiResponse<string>.GetFail(ApiReturnCode.ParamError, "参数有误"));
        }

        [HttpGet("GetUser")]
        public async Task<ActionResult> GetUser(string id)
        {
            User user = await _jwtHelper.UserAsync<User>(GetToken());
            return Ok(ApiResponse<User>.GetSucceed(user));
        }
    }
}

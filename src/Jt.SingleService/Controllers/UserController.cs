using Jt.SingleService.Service.UserSvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jt.SingleService.Controllers
{
    [Route("User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserSvc _userSvc;

        public UserController(IUserSvc userSvc)
        {
            _userSvc = userSvc;
        }

        [HttpGet("GetUser")]
        public IActionResult GetUser()
        {
            return Ok();
        }
    }
}

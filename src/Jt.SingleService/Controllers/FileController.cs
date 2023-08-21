using Jt.SingleService.Core;
using Jt.SingleService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jt.SingleService.Controllers
{
    [Route("File")]
    [AllowAnonymous]
    public class FileController : BaseController
    {
        private readonly IFileSvc _fileSvc;

        public FileController(IFileSvc fileSvc, JwtHelper jwtHelper) : base(jwtHelper)
        {
            _fileSvc = fileSvc;
        }

        [HttpPost("UploadAvatar")]
        public async Task<ActionResult> UploadAvatar(IFormFile file)
        {
            string userId = Guid.NewGuid().ToString().Substring(0, 6);
            var path = await _fileSvc.UploadAvatarAsync(file, userId + "_" + file.FileName);
            return Ok(path);
        }
    }
}

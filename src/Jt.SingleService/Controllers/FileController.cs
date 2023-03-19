using Jt.SingleService.Core.Attributes;
using Jt.SingleService.Core.Enums;
using Jt.SingleService.Core.Jwt;
using Jt.SingleService.Service.FileSvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jt.SingleService.Controllers
{
    [Route("File")]
    [AllowAnonymous]
    public class FileController : BaseController
    {
        private readonly IFileSvc _fileSvc;
        private JwtHelper _jwtHelper;

        public FileController(IFileSvc fileSvc, JwtHelper jwtHelper)
        {
            _fileSvc = fileSvc;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("UploadAvatar")]
        public async Task<ActionResult> UploadAvatar(IFormFile file)
        {
            string userId = Guid.NewGuid().ToString().Substring(0, 6);
            string path = await _fileSvc.UploadAvatarAsync(file, userId + "_" + file.FileName);
            return Successed(path);
        }
    }
}

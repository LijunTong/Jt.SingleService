using Jt.Cms.Core.Attributes;
using Jt.Cms.Core.Enums;
using Jt.Cms.Core.Jwt;
using Jt.Cms.Service.FileSvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jt.Cms.Controllers
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

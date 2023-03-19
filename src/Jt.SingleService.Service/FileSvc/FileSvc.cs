using Jt.SingleService.Lib.DI;
using Jt.SingleService.Lib.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Service.FileSvc
{
    public class FileSvc : IFileSvc, ITransientInterface
    {
        private const string BaseDir = "Files";
        private const string AvatarDir = "Avatars";

        public async Task<string> UploadAvatarAsync(IFormFile file, string fileName)
        {
            return await UploadFileAsync(file, Path.Combine(AvatarDir, fileName));
        }

        public async Task<string> UploadFileAsync(IFormFile file, string fileName)
        {
            string filepath = CHelperAppDomain.CombineWithCreate(BaseDir, fileName);
            using (var fiLeStream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(fiLeStream);
            }
            return Path.Combine(BaseDir, fileName);
        }
    }
}

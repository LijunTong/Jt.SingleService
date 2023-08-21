using Jt.SingleService.Core;
using Jt.Common.Tool.DI;
using Jt.Common.Tool.Helper;
using Microsoft.AspNetCore.Http;

namespace Jt.SingleService.Service
{
    public class FileSvc : IFileSvc, ITransientDIInterface
    {
        private const string BaseDir = "Files";
        private const string AvatarDir = "Avatars";

        public async Task<ApiResponse<string>> UploadAvatarAsync(IFormFile file, string fileName)
        {
            var data = await UploadFileAsync(file, Path.Combine(AvatarDir, fileName));
            return data;
        }

        public async Task<ApiResponse<string>> UploadFileAsync(IFormFile file, string fileName)
        {
            string filepath = AppDomainHelper.CreateDirectoryInBaseDirectory(BaseDir, fileName);
            using (var fiLeStream = new FileStream(filepath, FileMode.Create))
            {
                await file.CopyToAsync(fiLeStream);
            }

            var data = Path.Combine(BaseDir, fileName);
            return ApiResponse<string>.Succeed(data);
        }
    }
}

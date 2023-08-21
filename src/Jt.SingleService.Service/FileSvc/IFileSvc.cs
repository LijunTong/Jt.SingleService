using Jt.SingleService.Core;
using Microsoft.AspNetCore.Http;

namespace Jt.SingleService.Service
{
    public interface IFileSvc
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="stream">stream</param>
        /// <param name="fileName">fileName</param>
        /// <returns>string</returns>
        Task<ApiResponse<string>> UploadFileAsync(IFormFile file, string fileName);

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="stream">stream</param>
        /// <param name="fileName">fileName</param>
        /// <returns>string</returns>
        Task<ApiResponse<string>> UploadAvatarAsync(IFormFile file, string fileName);
    }
}

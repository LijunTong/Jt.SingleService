using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Service.FileSvc
{
    public interface IFileSvc
    {
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="stream">stream</param>
        /// <param name="fileName">fileName</param>
        /// <returns>string</returns>
        Task<string> UploadFileAsync(IFormFile file, string fileName);

        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="stream">stream</param>
        /// <param name="fileName">fileName</param>
        /// <returns>string</returns>
        Task<string> UploadAvatarAsync(IFormFile file, string fileName);
    }
}

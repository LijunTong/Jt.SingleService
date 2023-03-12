using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jt.SingleService.Core.Utils
{
    public class CHelperCookie
    {
        static IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();

        /// <summary>
        /// 设置cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetCookie(string key, string value)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value);
        }

        /// <summary>
        /// 获取cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCookie(string key)
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(key, out string value);
            if (string.IsNullOrEmpty(value))
                value = string.Empty;
            return value;
        }

        /// <summary>
        /// 删除指定的cookie
        /// </summary>
        /// <param name="key">键</param>
        public void DeleteCookies(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }
    }
}

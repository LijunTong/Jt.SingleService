using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jt.SingleService.Core.Utils
{
    public class CHelperSession
    {
        static IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();

        /// <summary>
        /// 设置Session
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void SetSession(string key, string value)
        {
            _httpContextAccessor.HttpContext.Session.SetString(key, value);
        }

        /// <summary>
        /// 获取Session
        /// </summary>
        /// <param name="key">键</param>
        /// <returns>返回对应的值</returns>
        public static string GetSession(string key)
        {
            var value = _httpContextAccessor.HttpContext.Session.GetString(key);
            if (string.IsNullOrEmpty(value))
                value = string.Empty;
            return value;
        }

        /// <summary>
        /// 移除session
        /// </summary>
        /// <param name="key"></param>
        public static void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Session.Remove(key);
        }

        /// <summary>
        /// 清空session
        /// </summary>
        public static void RemoveAll()
        {
            _httpContextAccessor.HttpContext.Session.Clear();

        }


    }
}

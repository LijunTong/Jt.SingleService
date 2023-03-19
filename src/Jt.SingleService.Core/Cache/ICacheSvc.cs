using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Cache
{
    /// <summary>
    /// 缓存服务接口
    /// </summary>
    public interface ICacheSvc
    {
        #region  验证缓存项是否存在
        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        Task<bool> ExistsAsync(string key);


        #endregion

        #region  添加缓存
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <returns></returns>
        Task<bool> AddAsync(string key, object value);


        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        Task<bool> AddAsync(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte);


        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <returns></returns>
        Task<bool> AddAsync(string key, object value, TimeSpan expiresIn, bool isSliding = false);

        Task<long> ListLeftPushAsync(string key, object value);

        Task<long> ListRightPushAsync(string key, object value);

        Task<bool> HashSetAsync(string key, string field, string value);

        Task<long> HashSetIncAsync(string key, string field, long value = 1);

        Task<long> HashSetDecAsync(string key, string field, long value = 1);

        Task<long> IncAsync(string key, long value = 1);

        Task<long> DecAsync(string key, long value = 1);

        #endregion

        #region  删除缓存
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        Task<bool> RemoveAsync(string key);

        /// <summary>
        /// 批量删除缓存
        /// </summary>
        /// <param name="keys">缓存Key集合</param>
        /// <returns></returns>
        Task RemoveAllAsync(IEnumerable<string> keys);

        /// <summary>
        /// 使用通配符找出所有的key然后逐个删除
        /// </summary>
        /// <param name="pattern">通配符</param>
        Task RemoveByPatternAsync(string pattern);

        /// <summary>
        /// 删除所有缓存
        /// </summary>
        Task RemoveCacheAllAsync();
        #endregion

        #region  获取缓存
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string key);


        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        Task<object> GetAsync(string key);


        /// <summary>
        /// 获取缓存集合
        /// </summary>
        /// <param name="keys">缓存Key集合</param>
        /// <returns></returns>
        Task<IDictionary<string, object>> GetAllAsync(IEnumerable<string> keys);

        Task<T> ListLeftPopAsync<T>(string key) where T : class;

        Task<T> ListRightPopAsync<T>(string key) where T : class;

        Task<List<T>> ListPopAllAsync<T>(string key) where T : class;

        Task<T> GetHashSetAsync<T>(string key, string field);

        Task<Dictionary<string, T>> GetHashSetAsync<T>(string key);

        #endregion

        #region  修改缓存
        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <returns></returns>
        Task<bool> ReplaceAsync(string key, object value);


        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        Task<bool> ReplaceAsync(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte);


        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <returns></returns>
        Task<bool> ReplaceAsync(string key, object value, TimeSpan expiresIn, bool isSliding = false);

        #endregion

        #region key过期

        Task<bool> KeyExpireAsync(string key, TimeSpan expire);
        Task<bool> KeyExpireAtAsync(string key, DateTime expireTime);

        #endregion

        #region 分布式锁

        Task<bool> LockTakeAsync(string key, string value, TimeSpan expiry);
        Task<bool> LockReleaseAsync(string key, string value);

        #endregion
    }
}

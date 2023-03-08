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
    public interface ICacheService
    {
        #region  验证缓存项是否存在
        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        bool Exists(string key);


        #endregion

        #region  添加缓存
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <returns></returns>
        bool Add(string key, object value);


        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        bool Add(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte);


        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <returns></returns>
        bool Add(string key, object value, TimeSpan expiresIn, bool isSliding = false);

        long ListLeftPush(string key, object value);
        long ListRightPush(string key, object value);
        bool HashSet(string key, string field, string value);
        long HashSetInc(string key, string field, long value = 1);
        long HashSetDec(string key, string field, long value = 1);
        long Inc(string key, long value = 1);
        long Dec(string key, long value = 1);

        #endregion

        #region  删除缓存
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        bool Remove(string key);

        /// <summary>
        /// 批量删除缓存
        /// </summary>
        /// <param name="keys">缓存Key集合</param>
        /// <returns></returns>
        void RemoveAll(IEnumerable<string> keys);

        /// <summary>
        /// 使用通配符找出所有的key然后逐个删除
        /// </summary>
        /// <param name="pattern">通配符</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        /// 删除所有缓存
        /// </summary>
        void RemoveCacheAll();
        #endregion

        #region  获取缓存
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        T Get<T>(string key);


        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        object Get(string key);


        /// <summary>
        /// 获取缓存集合
        /// </summary>
        /// <param name="keys">缓存Key集合</param>
        /// <returns></returns>
        IDictionary<string, object> GetAll(IEnumerable<string> keys);

        T ListLeftPop<T>(string key) where T : class;
        T ListRightPop<T>(string key) where T : class;
        List<T> ListPopAll<T>(string key) where T : class;

        T GetHashSet<T>(string key, string field);
        Dictionary<string, T> GetHashSet<T>(string key);
        #endregion

        #region  修改缓存
        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <returns></returns>
        bool Replace(string key, object value);


        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        bool Replace(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte);


        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <returns></returns>
        bool Replace(string key, object value, TimeSpan expiresIn, bool isSliding = false);

        #endregion

        #region key过期

        bool KeyExpire(string key, TimeSpan expire);
        bool KeyExpireAt(string key, DateTime expireTime);

        #endregion

        #region 分布式锁

        bool LockTake(string key, string value, TimeSpan expiry);
        bool LockRelease(string key, string value);

        #endregion
    }
}

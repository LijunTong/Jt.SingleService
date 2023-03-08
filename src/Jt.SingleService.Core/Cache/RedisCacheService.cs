using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Text.Json;

namespace Jt.SingleService.Core.Cache
{
    /// <summary>
    /// Redis缓存操作
    /// </summary>
    public class RedisCacheService : ICacheService
    {
        /// <summary>
        /// IDatabase
        /// </summary>
        protected IDatabase _cache;

        /// <summary>
        /// ConnectionMultiplexer
        /// </summary>
        private ConnectionMultiplexer _connection;

        /// <summary>
        /// _instance
        /// </summary>
        private readonly string _instance;

        private readonly JsonSerializerOptions _jsonOptions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <param name="database"></param>
        /// <param name="jsonOptions"></param>
        public RedisCacheService(IOptionsMonitor<AppSettings> setting,
                                 JsonSerializerOptions jsonOptions)
        {
            var appSetting = setting.CurrentValue;
            _connection = ConnectionMultiplexer.Connect(appSetting.Redis.RedisConnectString);
            _cache = _connection.GetDatabase(appSetting.Redis.Database);
            _instance = appSetting.Redis.Instance;
            _jsonOptions = jsonOptions;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetKeyForRedis(string key)
        {
            return _instance + "_" + key;
        }

        #region 验证缓存项是否存在
        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public bool Exists(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.KeyExists(GetKeyForRedis(key));
        }
        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public Task<bool> ExistsAsync(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.KeyExistsAsync(GetKeyForRedis(key));
        }
        #endregion

        #region 添加缓存
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <returns></returns>
        public bool Add(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _cache.StringSet(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions));
        }
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间,Redis中无效）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        public bool Add(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _cache.StringSet(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions), expiressAbsoulte);
        }
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">缓存Value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间,Redis中无效）</param>
        /// <returns></returns>
        public bool Add(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }


            return _cache.StringSet(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions), expiresIn);
        }

        /// <summary>
        /// 列表左插入
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public long ListLeftPush(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.ListLeftPush(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions));
        }

        /// <summary>
        /// 列表右插入
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public long ListRightPush(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.ListRightPush(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions));
        }

        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool HashSet(string key, string field, string value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.HashSet(GetKeyForRedis(key), field, value);
        }

        /// <summary>
        /// 哈希表自增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public long HashSetInc(string key, string field, long value = 1)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.HashIncrement(GetKeyForRedis(key), field, value);
        }

        /// <summary>
        /// 哈希表自减
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public long HashSetDec(string key, string field, long value = 1)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.HashDecrement(GetKeyForRedis(key), field, value);
        }

        public long Inc(string key, long value = 1)
        {
            return _cache.StringIncrement(key, value);
        }

        public long Dec(string key, long value = 1)
        {
            return _cache.StringDecrement(key, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _cache.StringSetAsync(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresSliding"></param>
        /// <param name="expiressAbsoulte"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _cache.StringSetAsync(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions), expiressAbsoulte);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresIn"></param>
        /// <param name="isSliding"></param>
        /// <returns></returns>
        public Task<bool> AddAsync(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _cache.StringSetAsync(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions), expiresIn);
        }

        /// <summary>
        /// 列表左插入
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task<long> ListLeftPushAsync(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.ListLeftPushAsync(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions));
        }

        /// <summary>
        /// 列表右插入
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task<long> ListRightPushAsync(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.ListRightPushAsync(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions));
        }

        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task<bool> HashSetAsync(string key, string field, string value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.HashSetAsync(GetKeyForRedis(key), field, value);
        }

        /// <summary>
        /// 哈希表自增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task<long> HashSetIncAsync(string key, string field, long value = 1)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.HashIncrementAsync(GetKeyForRedis(key), field, value);
        }

        /// <summary>
        /// 哈希表自减
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Task<long> HashSetDecAsync(string key, string field, long value = 1)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.HashDecrementAsync(GetKeyForRedis(key), field, value);
        }


        #endregion

        #region 删除缓存
        /// <summary>
        /// 删除缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.KeyDelete(GetKeyForRedis(key));
        }
        /// <summary>
        /// 批量删除缓存
        /// </summary>
        /// <param name="keys">缓存Key集合</param>
        /// <returns></returns>
        public void RemoveAll(IEnumerable<string> keys)
        {
            if (keys == null)
            {
                throw new ArgumentNullException(nameof(keys));
            }

            keys.ToList().ForEach(item => Remove(item));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<bool> RemoveAsync(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _cache.KeyDeleteAsync(GetKeyForRedis(key));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public Task RemoveAllAsync(IEnumerable<string> keys)
        {
            if (keys == null)
            {
                throw new ArgumentNullException(nameof(keys));
            }
            return Task.Run(() =>
            {
                keys.ToList().ForEach(item => RemoveAsync(item));
            });
        }
        /// <summary>
        /// 使用通配符找出所有的key然后逐个删除
        /// </summary>
        /// <param name="pattern">通配符</param>
        public virtual void RemoveByPattern(string pattern)
        {
            foreach (var ep in _connection.GetEndPoints())
            {
                var server = _connection.GetServer(ep);
                var keys = server.Keys(pattern: "*" + pattern + "*", database: _cache.Database);
                foreach (var key in keys)
                    _cache.KeyDelete(key);
            }
        }


        /// <summary>
        /// 删除所有缓存
        /// </summary>
        public void RemoveCacheAll()
        {
            RemoveByPattern("");
        }
        #endregion

        #region 获取缓存

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var value = _cache.StringGet(GetKeyForRedis(key));

            if (!value.HasValue)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(value, _jsonOptions);
        }
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public object Get(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var value = _cache.StringGet(GetKeyForRedis(key));

            if (!value.HasValue)
            {
                return null;
            }

            return JsonSerializer.Deserialize<object>(value, _jsonOptions);
            //string json = value.ToString();
            //return Newtonsoft.Json.JsonConvert.DeserializeObject(json);


        }
        /// <summary>
        /// 获取缓存集合
        /// </summary>
        /// <param name="keys">缓存Key集合</param>
        /// <returns></returns>
        public IDictionary<string, object> GetAll(IEnumerable<string> keys)
        {
            if (keys == null)
            {
                throw new ArgumentNullException(nameof(keys));
            }
            var dict = new Dictionary<string, object>();

            keys.ToList().ForEach(item => dict.Add(item, Get(GetKeyForRedis(item))));

            return dict;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<T> GetAsync<T>(string key) where T : class
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return Task.Run(async () =>
            {
                var value = await _cache.StringGetAsync(GetKeyForRedis(key));
                if (!value.HasValue)
                {
                    return default(T);
                }
                return JsonSerializer.Deserialize<T>(value, _jsonOptions);
            });

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<object> GetAsync(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return Task.Run(async () =>
            {
                var value = await _cache.StringGetAsync(GetKeyForRedis(key));

                if (!value.HasValue)
                {
                    return null;
                }

                return JsonSerializer.Deserialize<object>(value, _jsonOptions);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public Task<IDictionary<string, object>> GetAllAsync(IEnumerable<string> keys)
        {
            IDictionary<string, object> dict = new Dictionary<string, object>();
            return Task.Run(() =>
            {
                keys.ToList().ForEach(item => dict.Add(item, Get(GetKeyForRedis(item))));

                return dict;
            });
        }

        /// <summary>
        /// 列表左获取
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public T ListLeftPop<T>(string key) where T : class
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }


            var value = _cache.ListLeftPop(GetKeyForRedis(key));

            if (!value.HasValue)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(value, _jsonOptions);
        }

        /// <summary>
        /// 列表左获取
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public Task<T> ListLeftPopAsync<T>(string key) where T : class
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return Task.Run(async () =>
            {
                var value = await _cache.ListLeftPopAsync(GetKeyForRedis(key));

                if (!value.HasValue)
                {
                    return default(T);
                }
                return JsonSerializer.Deserialize<T>(value, _jsonOptions);
            });
        }

        /// <summary>
        /// 列表右获取
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public T ListRightPop<T>(string key) where T : class
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            var value = _cache.ListRightPop(GetKeyForRedis(key));

            if (!value.HasValue)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(value, _jsonOptions);
        }

        /// <summary>
        /// 列表右获取
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public Task<T> ListRightPopAsync<T>(string key) where T : class
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return Task.Run(async () =>
            {
                var value = await _cache.ListRightPopAsync(GetKeyForRedis(key));

                if (!value.HasValue)
                {
                    return default(T);
                }
                return JsonSerializer.Deserialize<T>(value, _jsonOptions);
            });


        }

        /// <summary>
        /// 列表全部获取
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public List<T> ListPopAll<T>(string key) where T : class
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            key = GetKeyForRedis(key);
            long length = _cache.ListLength(key);
            var value = _cache.ListRange(key, 0, length - 1);
            List<T> ts = new List<T>();
            foreach (var item in value)
            {
                ts.Add(JsonSerializer.Deserialize<T>(item, _jsonOptions));
            }
            _cache.ListTrim(key, length, -1);
            return ts;
        }

        /// <summary>
        /// 列表全部获取
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <returns></returns>
        public Task<List<T>> ListPopAllAsync<T>(string key) where T : class
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return Task.Run(async () =>
            {
                key = GetKeyForRedis(key);
                long length = await _cache.ListLengthAsync(key);
                var value = await _cache.ListRangeAsync(key, 0, length - 1);
                List<T> ts = new List<T>();
                foreach (var item in value)
                {
                    ts.Add(JsonSerializer.Deserialize<T>(item, _jsonOptions));
                }
                _cache.ListTrim(key, length, -1);
                return ts;
            });

        }

        /// <summary>
        /// 获取hash set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public T GetHashSet<T>(string key, string field)
        {
            var value = _cache.HashGet(GetKeyForRedis(key), field);
            if (!value.HasValue)
            {
                return default;
            }
            return JsonSerializer.Deserialize<T>(value, _jsonOptions);
        }

        /// <summary>
        /// 获取hash set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <returns></returns>
        public Dictionary<string, T> GetHashSet<T>(string key)
        {
            Dictionary<string, T> keyValues = new Dictionary<string, T>();
            var value = _cache.HashGetAll(GetKeyForRedis(key));
            foreach (var item in value)
            {
                keyValues.Add(item.Name, JsonSerializer.Deserialize<T>(item.Value, _jsonOptions));
            }
            return keyValues;
        }

        #endregion

        #region 修改缓存
        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <returns></returns>
        public bool Replace(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (Exists(key))
                if (!Remove(key))
                    return false;

            return Add(key, value);

        }
        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <param name="expiresSliding">滑动过期时长（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <param name="expiressAbsoulte">绝对过期时长</param>
        /// <returns></returns>
        public bool Replace(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (Exists(key))
                if (!Remove(key))
                    return false;

            return Add(key, value, expiresSliding, expiressAbsoulte);
        }
        /// <summary>
        /// 修改缓存
        /// </summary>
        /// <param name="key">缓存Key</param>
        /// <param name="value">新的缓存Value</param>
        /// <param name="expiresIn">缓存时长</param>
        /// <param name="isSliding">是否滑动过期（如果在过期时间内有操作，则以当前时间点延长过期时间）</param>
        /// <returns></returns>
        public bool Replace(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (Exists(key))
                if (!Remove(key)) return false;

            return Add(key, value, expiresIn, isSliding);
        }


        public Task<bool> ReplaceAsync(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return Task.Run(() =>
            {
                if (Exists(key))
                    if (!Remove(key))
                        return false;

                return Add(key, value);
            });
        }

        public Task<bool> ReplaceAsync(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return Task.Run(() =>
            {
                if (Exists(key))
                    if (!Remove(key))
                        return false;

                return Add(key, value, expiresSliding, expiressAbsoulte);
            });
        }

        public Task<bool> ReplaceAsync(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return Task.Run(() =>
            {
                if (Exists(key))
                    if (!Remove(key))
                        return false;

                return Add(key, value, expiresIn, isSliding);
            });
        }
        #endregion

        #region key过期

        public bool KeyExpire(string key, TimeSpan expire)
        {
            return _cache.KeyExpire(GetKeyForRedis(key), expire);
        }

        public bool KeyExpireAt(string key, DateTime expireTime)
        {
            return _cache.KeyExpire(key, expireTime);
        }
        #endregion

        #region 分布式锁

        public bool LockTake(string key, string value, TimeSpan expiry)
        {
            return _cache.LockTake(key, value, expiry);
        }

        public bool LockRelease(string key, string value)
        {
            return _cache.LockRelease(key, value);
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            if (_connection != null)
                _connection.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
using Jt.Common.Tool.DI;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Text.Json;

namespace Jt.Cms.Core
{
    /// <summary>
    /// Redis缓存操作
    /// </summary>
    public class RedisCacheSvc : ICacheSvc, ISingletonDIInterface
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
        public RedisCacheSvc(IOptionsMonitor<AppSettings> setting,
                                 IOptions<JsonSerializerOptions> jsonOptions)
        {
            var appSetting = setting.CurrentValue;
            _connection = ConnectionMultiplexer.Connect(appSetting.Redis.RedisConnectString);
            _cache = _connection.GetDatabase(appSetting.Redis.Database);
            _instance = appSetting.Redis.Instance;
            _jsonOptions = jsonOptions.Value;
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


        public async Task<long> IncAsync(string key, long value = 1)
        {
            return await _cache.StringIncrementAsync(key, value);
        }

        public async Task<long> DecAsync(string key, long value = 1)
        {
            return await _cache.StringDecrementAsync(key, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return await _cache.StringSetAsync(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresSliding"></param>
        /// <param name="expiressAbsoulte"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return await _cache.StringSetAsync(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions), expiressAbsoulte);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiresIn"></param>
        /// <param name="isSliding"></param>
        /// <returns></returns>
        public async Task<bool> AddAsync(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return await _cache.StringSetAsync(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions), expiresIn);
        }

        /// <summary>
        /// 列表左插入
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<long> ListLeftPushAsync(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return await _cache.ListLeftPushAsync(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions));
        }

        /// <summary>
        /// 列表右插入
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<long> ListRightPushAsync(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return await _cache.ListRightPushAsync(GetKeyForRedis(key), JsonSerializer.Serialize(value, _jsonOptions));
        }

        /// <summary>
        /// 哈希表
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<bool> HashSetAsync(string key, string field, string value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return await _cache.HashSetAsync(GetKeyForRedis(key), field, value);
        }

        /// <summary>
        /// 哈希表自增
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<long> HashSetIncAsync(string key, string field, long value = 1)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return await _cache.HashIncrementAsync(GetKeyForRedis(key), field, value);
        }

        /// <summary>
        /// 哈希表自减
        /// </summary>
        /// <param name="key"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<long> HashSetDecAsync(string key, string field, long value = 1)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return await _cache.HashDecrementAsync(GetKeyForRedis(key), field, value);
        }


        #endregion

        #region 删除缓存

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<bool> RemoveAsync(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return await _cache.KeyDeleteAsync(GetKeyForRedis(key));
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
                keys.ToList().ForEach(async item => await RemoveAsync(item));
            });
        }

        /// <summary>
        /// 使用通配符找出所有的key然后逐个删除
        /// </summary>
        /// <param name="pattern">通配符</param>
        public virtual async Task RemoveByPatternAsync(string pattern)
        {
            foreach (var ep in _connection.GetEndPoints())
            {
                var server = _connection.GetServer(ep);
                var keys = server.Keys(pattern: "*" + pattern + "*", database: _cache.Database);
                foreach (var key in keys)
                    await _cache.KeyDeleteAsync(key);
            }
        }


        /// <summary>
        /// 删除所有缓存
        /// </summary>
        public async Task RemoveCacheAllAsync()
        {
            await RemoveByPatternAsync("");
        }
        #endregion

        #region 获取缓存

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public Task<T> GetAsync<T>(string key)
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
            return Task.Run((Func<IDictionary<string, object>>)(() =>
            {
                keys.ToList().ForEach((Action<string>)(item => dict.Add(item, (object)this.GetAsync(GetKeyForRedis(item)))));

                return dict;
            }));
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
        public async Task<T> GetHashSetAsync<T>(string key, string field)
        {
            var value = await _cache.HashGetAsync(GetKeyForRedis(key), field);
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
        public async Task<Dictionary<string, T>> GetHashSetAsync<T>(string key)
        {
            Dictionary<string, T> keyValues = new Dictionary<string, T>();
            var value = await _cache.HashGetAllAsync(GetKeyForRedis(key));
            foreach (var item in value)
            {
                keyValues.Add(item.Name, JsonSerializer.Deserialize<T>(item.Value, _jsonOptions));
            }
            return keyValues;
        }

        #endregion

        #region 修改缓存


        public async Task<bool> ReplaceAsync(string key, object value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (await ExistsAsync(key))
                if (!await RemoveAsync(key))
                    return false;

            return await this.AddAsync(key, value);
        }

        public async Task<bool> ReplaceAsync(string key, object value, TimeSpan expiresSliding, TimeSpan expiressAbsoulte)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (await ExistsAsync(key))
                if (!await RemoveAsync(key))
                    return false;

            return await AddAsync(key, value, expiresSliding, expiressAbsoulte);
        }

        public async Task<bool> ReplaceAsync(string key, object value, TimeSpan expiresIn, bool isSliding = false)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (await ExistsAsync(key))
                if (!await RemoveAsync(key))
                    return false;

            return await AddAsync(key, value, expiresIn, isSliding);
        }
        #endregion

        #region key过期

        public async Task<bool> KeyExpireAsync(string key, TimeSpan expire)
        {
            return await _cache.KeyExpireAsync(GetKeyForRedis(key), expire);
        }

        public async Task<bool> KeyExpireAtAsync(string key, DateTime expireTime)
        {
            return await _cache.KeyExpireAsync(key, expireTime);
        }
        #endregion

        #region 分布式锁

        public async Task<bool> LockTakeAsync(string key, string value, TimeSpan expiry)
        {
            return await _cache.LockTakeAsync(key, value, expiry);
        }

        public async Task<bool> LockReleaseAsync(string key, string value)
        {
            return await _cache.LockReleaseAsync(key, value);
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
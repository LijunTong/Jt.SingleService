using Jt.SingleService.Core;
using Jt.SingleService.Data;
using Jt.Common.Tool.DI;

namespace Jt.SingleService.Service
{
    public class SysLogCacheSvc : ISysLogCacheSvc, ITransientDIInterface
    {
        private readonly string KeySysLog = "KeySysLog";
        private readonly string KeyIpRecordStats = "KeyIpRecordStats";
        private readonly string KeyActionRecordStats = "KeyActionRecordStats";
        private readonly string KeyTotalRecordStats = "KeyTotalRecordStats";
        private ICacheSvc _cacheSvc;
        private ISysLogSvc _logSvc;


        public SysLogCacheSvc(ICacheSvc CacheSvc, ISysLogSvc logSvc)
        {
            _cacheSvc = CacheSvc;
            _logSvc = logSvc;
        }

        public async Task<List<SysLog>> PopLogAsync()
        {
            return await _cacheSvc.ListPopAllAsync<SysLog>(KeySysLog);
        }

        public async Task PushLogAsync(SysLog sysLog)
        {
            await _cacheSvc.ListRightPushAsync(KeySysLog, sysLog);
        }

        public async Task IncIpStatsAsync(string ip)
        {
            await _cacheSvc.HashSetIncAsync(KeyIpRecordStats, ip);
        }

        public async Task<List<KeyValueDto<long>>> GetIpStatsAsync()
        {
            List<KeyValueDto<long>> result = new List<KeyValueDto<long>>();
            if (await _cacheSvc.ExistsAsync(KeyIpRecordStats))
            {
                var val = await _cacheSvc.GetHashSetAsync<long>(KeyIpRecordStats);
                foreach (var item in val)
                {
                    result.Add(new KeyValueDto<long>
                    {
                        Key = item.Key,
                        Value = item.Value,
                    });
                }
            }
            else
            {
                result = (await _logSvc.GetIpStatsAsync()).Data;
                foreach (var item in result)
                {
                    await _cacheSvc.HashSetAsync(KeyIpRecordStats, item.Key, item.Value.ToString());
                }
            }
            result = result.OrderByDescending(x => x.Value).Take(10).ToList();
            return result;
        }

        public async Task IncTodayIpStatsAsync(string ip)
        {
            string key = $"{DateTime.Now:d}{KeyIpRecordStats}";
            if (!await _cacheSvc.ExistsAsync(key))
            {
                await _cacheSvc.HashSetIncAsync(key, ip);
                await _cacheSvc.KeyExpireAtAsync(key, DateTime.Now.AddDays(7));
            }
            else
            {
                await _cacheSvc.HashSetIncAsync(key, ip);
            }
        }

        public async Task<List<KeyValueDto<long>>> GetTodayIpStatsAsync()
        {
            List<KeyValueDto<long>> result = new List<KeyValueDto<long>>();
            string key = $"{DateTime.Now:d}{KeyIpRecordStats}";
            if (await _cacheSvc.ExistsAsync(key))
            {
                var val = await _cacheSvc.GetHashSetAsync<long>(key);
                foreach (var item in val)
                {
                    result.Add(new KeyValueDto<long>
                    {
                        Key = item.Key,
                        Value = item.Value,
                    });
                }
            }
            else
            {
                result = (await _logSvc.GetTodayIpStatsAsync(DateTime.Now)).Data;
                foreach (var item in result)
                {
                    await _cacheSvc.HashSetAsync(key, item.Key, item.Value.ToString());
                }
                await _cacheSvc.KeyExpireAtAsync(key, DateTime.Now.AddDays(7));
            }
            result = result.OrderByDescending(x => x.Value).Take(10).ToList();
            return result;
        }

        public async Task IncActionStatsAsync(string controller, string action)
        {
            string field = $"/{controller}/{action}";
            await _cacheSvc.HashSetIncAsync(KeyActionRecordStats, field);
        }

        public async Task<List<KeyValueDto<long>>> GetActionStatsAsync()
        {
            List<KeyValueDto<long>> result = new List<KeyValueDto<long>>();
            if (await _cacheSvc.ExistsAsync(KeyActionRecordStats))
            {
                var val = await _cacheSvc.GetHashSetAsync<long>(KeyActionRecordStats);
                foreach (var item in val)
                {
                    result.Add(new KeyValueDto<long>
                    {
                        Key = item.Key,
                        Value = item.Value
                    });
                }
            }
            else
            {
                var dbResult = await _logSvc.GetActionStatsAsync();
                foreach (var item in dbResult.Data)
                {
                    string field = $"/{item.controller}/{item.action}";
                    await _cacheSvc.HashSetAsync(KeyActionRecordStats, field, item.count.ToString());
                    result.Add(new KeyValueDto<long>
                    {
                        Key = field,
                        Value = item.count
                    });
                }
            }
            result = result.OrderByDescending(x => x.Value).Take(10).ToList();
            return result;
        }

        public async Task IncTodayActionStatsAsync(string controller, string action)
        {
            string key = $"{DateTime.Now:d}{KeyActionRecordStats}";
            string field = $"/{controller}/{action}";
            if (!await _cacheSvc.ExistsAsync(key))
            {
                await _cacheSvc.HashSetIncAsync(key, field);
                await _cacheSvc.KeyExpireAtAsync(key, DateTime.Now.AddDays(7));
            }
            else
            {
                await _cacheSvc.HashSetIncAsync(key, field);
            }
        }

        public async Task<List<KeyValueDto<long>>> GetTodayActionStatsAsync()
        {
            List<KeyValueDto<long>> result = new List<KeyValueDto<long>>();
            string key = $"{DateTime.Now:d}{KeyActionRecordStats}";
            if (await _cacheSvc.ExistsAsync(key))
            {
                var val = await _cacheSvc.GetHashSetAsync<long>(key);
                foreach (var item in val)
                {
                    result.Add(new KeyValueDto<long>
                    {
                        Key = item.Key,
                        Value = item.Value
                    });
                }
            }
            else
            {
                var dbResult = await _logSvc.GetTodayActionStatsAsync(DateTime.Now);
                foreach (var item in dbResult.Data)
                {
                    string field = $"/{item.controller}/{item.action}";
                    await _cacheSvc.HashSetAsync(key, field, item.count.ToString());
                    result.Add(new KeyValueDto<long>
                    {
                        Key = field,
                        Value = item.count
                    });
                }
                await _cacheSvc.KeyExpireAtAsync(key, DateTime.Now.AddDays(7));
            }
            result = result.OrderByDescending(x => x.Value).Take(10).ToList();
            return result;
        }

        public async Task IncTotalStatsAsync()
        {
            await _cacheSvc.IncAsync(KeyTotalRecordStats);
        }
        public async Task<long> GetTotalStatsAsync()
        {
            if (await _cacheSvc.ExistsAsync(KeyTotalRecordStats))
            {
                return await _cacheSvc.GetAsync<long>(KeyTotalRecordStats);
            }
            else
            {
                var result = (await _logSvc.GetTotalStatsAsync()).Data;
                await _cacheSvc.AddAsync(KeyTotalRecordStats, result);
                return result;
            }
        }

        public async Task IncTodayTotalStatsAsync()
        {
            string key = $"{DateTime.Now:d}{KeyTotalRecordStats}";
            if (!await _cacheSvc.ExistsAsync(key))
            {
                await _cacheSvc.IncAsync(key);
                await _cacheSvc.KeyExpireAtAsync(key, DateTime.Now.AddDays(7));
            }
            else
            {
                await _cacheSvc.IncAsync(key);
            }
        }
        public async Task<long> GetTodayTotalStatsAsync()
        {
            string key = $"{DateTime.Now:d}{KeyTotalRecordStats}";
            if (await _cacheSvc.ExistsAsync(key))
            {
                return (long)await _cacheSvc.GetAsync(key);
            }
            else
            {
                long result = (await _logSvc.GetTodayTotalStatsAsync(DateTime.Now)).Data;
                await _cacheSvc.AddAsync(key, result);
                await _cacheSvc.KeyExpireAtAsync(key, DateTime.Now.AddDays(7));
                return result;
            }
        }

        public async Task<List<KeyValueDto<long>>> GetWeekTotalStatsAsync()
        {
            List<KeyValueDto<long>> weekTotalStats = new List<KeyValueDto<long>>();
            for (int i = 6; i >= 0; i--)
            {
                var time = DateTime.Now.AddDays(-i);
                string key = $"{time:d}{KeyTotalRecordStats}";
                if (await _cacheSvc.ExistsAsync(key))
                {
                    weekTotalStats.Add(new KeyValueDto<long>
                    {
                        Key = $"{time:d}",
                        Value = await _cacheSvc.GetAsync<long>(key)
                    });
                }
                else
                {
                    long result = (await _logSvc.GetTodayTotalStatsAsync(time)).Data;
                    await _cacheSvc.AddAsync(key, result);
                    await _cacheSvc.KeyExpireAtAsync(key, time.AddDays(7));
                    weekTotalStats.Add(new KeyValueDto<long>
                    {
                        Key = $"{time:d}",
                        Value = result
                    });
                }
            }
            return weekTotalStats;
        }
    }
}

using JT.Framework.Core.IService;
using JT.Framework.Core.Model;
using JT.Framework.Library.CommonService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT.Framework.Core.Service
{
    public class SysLogCacheSvc : ISysLogCacheSvc
    {
        private readonly string KeySysLog = "KeySysLog";
        private readonly string KeyIpRecordStats = "KeyIpRecordStats";
        private readonly string KeyActionRecordStats = "KeyActionRecordStats";
        private readonly string KeyTotalRecordStats = "KeyTotalRecordStats";
        private ICacheService _cacheService;
        private ISysLogService _logService;


        public SysLogCacheSvc(ICacheService cacheService, ISysLogService logService)
        {
            _cacheService = cacheService;
            _logService = logService;
        }

        public List<SysLog> PopLog()
        {
            return _cacheService.ListPopAll<SysLog>(KeySysLog);
        }

        public void PushLog(SysLog sysLog)
        {
            _cacheService.ListRightPush(KeySysLog, sysLog);
        }

        public void IncIpStats(string ip)
        {
            _cacheService.HashSetInc(KeyIpRecordStats, ip);
        }

        public List<KeyValueDto<long>> GetIpStats()
        {
            List<KeyValueDto<long>> result = new List<KeyValueDto<long>>();
            if (_cacheService.Exists(KeyIpRecordStats))
            {
                var val = _cacheService.GetHashSet<long>(KeyIpRecordStats);
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
                result = _logService.GetIpStats();
                foreach (var item in result)
                {
                    _cacheService.HashSet(KeyIpRecordStats, item.Key, item.Value.ToString());
                }
            }
            result = result.OrderByDescending(x => x.Value).Take(10).ToList();
            return result;
        }

        public void IncTodayIpStats(string ip)
        {
            string key = $"{DateTime.Now:d}{KeyIpRecordStats}";
            if (!_cacheService.Exists(key))
            {
                _cacheService.HashSetInc(key, ip);
                _cacheService.KeyExpireAt(key, DateTime.Now.AddDays(7));
            }
            else
            {
                _cacheService.HashSetInc(key, ip);
            }
        }

        public List<KeyValueDto<long>> GetTodayIpStats()
        {
            List<KeyValueDto<long>> result = new List<KeyValueDto<long>>();
            string key = $"{DateTime.Now:d}{KeyIpRecordStats}";
            if (_cacheService.Exists(key))
            {
                var val = _cacheService.GetHashSet<long>(key);
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
                result = _logService.GetTodayIpStats(DateTime.Now);
                foreach (var item in result)
                {
                    _cacheService.HashSet(key, item.Key, item.Value.ToString());
                }
                _cacheService.KeyExpireAt(key, DateTime.Now.AddDays(7));
            }
            result = result.OrderByDescending(x => x.Value).Take(10).ToList();
            return result;
        }

        public void IncActionStats(string controller, string action)
        {
            string field = $"/{controller}/{action}";
            _cacheService.HashSetInc(KeyActionRecordStats, field);
        }

        public List<KeyValueDto<long>> GetActionStats()
        {
            List<KeyValueDto<long>> result = new List<KeyValueDto<long>>();
            if (_cacheService.Exists(KeyActionRecordStats))
            {
                var val = _cacheService.GetHashSet<long>(KeyActionRecordStats);
                foreach (var item in val)
                {
                    result.Add(new KeyValueDto<long>
                    {
                        Key= item.Key,
                        Value = item.Value
                    });
                }
            }
            else
            {
                var dbResult = _logService.GetActionStats();
                foreach (var item in dbResult)
                {
                    string field = $"/{item.controller}/{item.action}";
                    _cacheService.HashSet(KeyActionRecordStats, field, item.count.ToString());
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

        public void IncTodayActionStats(string controller, string action)
        {
            string key = $"{DateTime.Now:d}{KeyActionRecordStats}";
            string field = $"/{controller}/{action}";
            if (!_cacheService.Exists(key))
            {
                _cacheService.HashSetInc(key, field);
                _cacheService.KeyExpireAt(key, DateTime.Now.AddDays(7));
            }
            else
            {
                _cacheService.HashSetInc(key, field);
            }
        }

        public List<KeyValueDto<long>> GetTodayActionStats()
        {
            List<KeyValueDto<long>> result = new List<KeyValueDto<long>>();
            string key = $"{DateTime.Now:d}{KeyActionRecordStats}";
            if (_cacheService.Exists(key))
            {
                var val = _cacheService.GetHashSet<long>(key);
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
                var dbResult = _logService.GetTodayActionStats(DateTime.Now);
                foreach (var item in dbResult)
                {
                    string field = $"/{item.controller}/{item.action}";
                    _cacheService.HashSet(key, field, item.count.ToString());
                    result.Add(new KeyValueDto<long>
                    {
                        Key = field,
                        Value = item.count
                    });
                }
                _cacheService.KeyExpireAt(key, DateTime.Now.AddDays(7));
            }
            result = result.OrderByDescending(x => x.Value).Take(10).ToList();
            return result;
        }

        public void IncTotalStats()
        {
            _cacheService.Inc(KeyTotalRecordStats);
        }
        public long GetTotalStats()
        {
            if (_cacheService.Exists(KeyTotalRecordStats))
            {
                return (long)_cacheService.Get<long>(KeyTotalRecordStats);
            }
            else
            {
                long result = _logService.GetTotalStats();
                _cacheService.Add(KeyTotalRecordStats, result);
                return result;
            }
        }

        public void IncTodayTotalStats()
        {
            string key = $"{DateTime.Now:d}{KeyTotalRecordStats}";
            if (!_cacheService.Exists(key))
            {
                _cacheService.Inc(key);
                _cacheService.KeyExpireAt(key, DateTime.Now.AddDays(7));
            }
            else
            {
                _cacheService.Inc(key);
            }
        }
        public long GetTodayTotalStats()
        {
            string key = $"{DateTime.Now:d}{KeyTotalRecordStats}";
            if (_cacheService.Exists(key))
            {
                return (long)_cacheService.Get(key);
            }
            else
            {
                long result = _logService.GetTodayTotalStats(DateTime.Now);
                _cacheService.Add(key, result);
                _cacheService.KeyExpireAt(key, DateTime.Now.AddDays(7));
                return result;
            }
        }

        public List<KeyValueDto<long>> GetWeekTotalStats()
        {
            List<KeyValueDto<long>> weekTotalStats = new List<KeyValueDto<long>>();
            for (int i = 6; i >= 0; i--)
            {
                var time = DateTime.Now.AddDays(-i);
                string key = $"{time:d}{KeyTotalRecordStats}";
                if (_cacheService.Exists(key))
                {
                    weekTotalStats.Add(new KeyValueDto<long>
                    {
                        Key = $"{time:d}",
                        Value = (long)_cacheService.Get<long>(key)
                    });
                }
                else
                {
                    long result = _logService.GetTodayTotalStats(time);
                    _cacheService.Add(key, result);
                    _cacheService.KeyExpireAt(key, time.AddDays(7));
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

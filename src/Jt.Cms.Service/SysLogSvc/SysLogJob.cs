using Microsoft.Extensions.Logging;
using Quartz;

namespace Jt.Cms.Service
{
    public class SysLogJob : IJob
    {
        private readonly ISysLogCacheSvc _sysLogCacheSvc;
        private readonly ISysLogSvc _sysLogSvc;
        private readonly ILogger<SysLogJob> _logger;

        public SysLogJob(ISysLogCacheSvc sysLogCacheService, ISysLogSvc sysLogService, ILogger<SysLogJob> logger)
        {
            _sysLogCacheSvc = sysLogCacheService;
            _sysLogSvc = sysLogService;
            _logger = logger;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var logs = await _sysLogCacheSvc.PopLogAsync();
                if (logs != null && logs.Count > 0)
                {
                    int pageSize = 500;
                    int pages = logs.Count / pageSize + 1;
                    for (int i = 0; i < pages; i++)
                    {
                        var log = logs.Skip(i * pageSize).Take(pageSize).ToList();
                        await _sysLogSvc.InsertListAsync(logs);
                    }
                    _logger.LogInformation($"SysLogJob:保存系统日志{logs.Count}条");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SysLogJob:保存系统日志异常:" + ex.Message);
            }
        }
    }
}

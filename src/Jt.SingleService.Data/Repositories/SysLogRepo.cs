using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Dto;
using Jt.SingleService.Core.Enums;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Data.Repositories
{
    public class SysLogRepo : BaseRepo<SysLog>, ISysLogRepo, ITransientInterface
    {
        public SysLogRepo (MysqlDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<ActionStatsDto>> GetActionStatsAsync()
        {
            var r =  await IQueryableAsync(x => x.Type == (int)EnumLogType.OpLog);
            return r.GroupBy(x => new { x.Controller, x.Action })
                .Select(x => new ActionStatsDto()
                {
                    controller = x.Key.Controller,
                    action = x.Key.Action,
                    count = x.Count(),
                }).ToList();
        }

        public async Task<List<KeyValueDto<long>>> GetIpStatsAsync()
        {
            var r = await IQueryableAsync(x => x.Type == (int)EnumLogType.OpLog);
            return r.GroupBy(x => x.RemoteAddress)
            .Select(x => new KeyValueDto<long>()
            {
                Key = x.Key,
                Value = x.Count(),
            }).ToList();
        }

        public async Task<List<ActionStatsDto>> GetTodayActionStatsAsync(DateTime dateTime)
        {
            var r = await IQueryableAsync(x => x.Type == (int)EnumLogType.OpLog && x.LogTime.Date == dateTime.Date);
            return r.GroupBy(x => new { x.Controller, x.Action })
              .Select(x => new ActionStatsDto()
              {
                  controller = x.Key.Controller,
                  action = x.Key.Action,
                  count = x.Count(),
              }).ToList();
        }

        public async Task<List<KeyValueDto<long>>> GetTodayIpStatsAsync(DateTime dateTime)
        {
            var r = await IQueryableAsync(x => x.Type == (int)EnumLogType.OpLog && x.LogTime.Date == dateTime.Date);
            return r.GroupBy(x => x.RemoteAddress)
             .Select(x => new KeyValueDto<long>()
             {
                 Key = x.Key,
                 Value = x.Count(),
             }).ToList();
        }

        public async Task<long> GetTodayTotalStatsAsync(DateTime dateTime)
        {
            var r = await IQueryableAsync(x => x.Type == (int)EnumLogType.OpLog && x.LogTime.Date == dateTime.Date);
            return r.Count();
        }

        public async Task<long> GetTotalStatsAsync()
        {
            var r =  await IQueryableAsync(x => x.Type == (int)EnumLogType.OpLog);
            return r.Count();
        }
    }
}

using Jt.Cms.Data.DbContexts;
using Jt.Cms.Data.Dto;
using Jt.Cms.Core.Enums;
using Jt.Cms.Data.Tables;
using Jt.Cms.Data.Repositories.Interface;
using Jt.Cms.Lib.DI;

namespace Jt.Cms.Data.Repositories.Impl
{
    public class SysLogRepo : BaseRepo<SysLog>, ISysLogRepo, ITransientInterface
    {
        public SysLogRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<ActionStatsDto>> GetActionStatsAsync()
        {
            var r = await IQueryableAsync(x => x.Type == (int)EnumLogType.OpLog);
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
            var r = await IQueryableAsync(x => x.Type == (int)EnumLogType.OpLog);
            return r.Count();
        }
    }
}

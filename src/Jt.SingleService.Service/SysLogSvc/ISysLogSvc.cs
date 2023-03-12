using Jt.SingleService.Core.Dto;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Service.SysLogSvc
{
    public interface ISysLogSvc : IBaseSvc<SysLog>
    {
        Task<List<KeyValueDto<long>>> GetTodayIpStatsAsync(DateTime dateTime);

         Task<List<KeyValueDto<long>>> GetIpStatsAsync();

         Task<List<ActionStatsDto>> GetTodayActionStatsAsync(DateTime dateTime);

         Task<List<ActionStatsDto>> GetActionStatsAsync();

         Task<long> GetTotalStatsAsync();

         Task<long> GetTodayTotalStatsAsync(DateTime dateTime);
    }
}
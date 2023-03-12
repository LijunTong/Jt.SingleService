using Jt.SingleService.Core.Tables;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Dto;

namespace Jt.SingleService.Core.Repositories
{
    public interface ISysLogRepo : IBaseRepo<SysLog>
    {
        Task<List<KeyValueDto<long>>> GetTodayIpStatsAsync(DateTime dateTime);

        Task<List<KeyValueDto<long>>> GetIpStatsAsync();

        Task<List<ActionStatsDto>> GetTodayActionStatsAsync(DateTime dateTime);

        Task<List<ActionStatsDto>> GetActionStatsAsync();

        Task<long> GetTodayTotalStatsAsync(DateTime dateTime);

        Task<long> GetTotalStatsAsync();
    }
}
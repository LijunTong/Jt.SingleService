using Jt.Cms.Data.Tables;
using Jt.Cms.Data.Dto;

namespace Jt.Cms.Data.Repositories.Interface
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
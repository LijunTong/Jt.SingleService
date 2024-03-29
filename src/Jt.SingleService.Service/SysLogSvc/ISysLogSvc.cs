using Jt.SingleService.Core;
using Jt.SingleService.Data;

namespace Jt.SingleService.Service
{
    public interface ISysLogSvc : IBaseSvc<SysLog>
    {
        Task<ApiResponse<List<KeyValueDto<long>>>> GetTodayIpStatsAsync(DateTime dateTime);

        Task<ApiResponse<List<KeyValueDto<long>>>> GetIpStatsAsync();

        Task<ApiResponse<List<ActionStatsDto>>> GetTodayActionStatsAsync(DateTime dateTime);

        Task<ApiResponse<List<ActionStatsDto>>> GetActionStatsAsync();

        Task<ApiResponse<long>> GetTotalStatsAsync();

        Task<ApiResponse<long>> GetTodayTotalStatsAsync(DateTime dateTime);

        Task<ApiResponse<PagerOutput<SysLog>>> GetLogsPagerListAsync(GetLogPagerReq req);
    }
}
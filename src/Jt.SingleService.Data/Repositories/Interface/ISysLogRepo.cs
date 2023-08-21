namespace Jt.SingleService.Data
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
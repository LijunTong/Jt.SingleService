using Jt.SingleService.Data.Dto;
using Jt.SingleService.Data.Tables;

namespace Jt.SingleService.Service.UserSvc
{
    public interface ISysLogCacheSvc
    {
        Task PushLogAsync(SysLog sysLog);

        Task<List<SysLog>> PopLogAsync();

        /// <summary>
        /// 访问次数按ip统计 自增
        /// </summary>
        /// <param name="ip"></param>
        Task IncIpStatsAsync(string ip);

        /// <summary>
        /// 获取ip统计
        /// </summary>
        /// <returns></returns>
        Task<List<KeyValueDto<long>>> GetIpStatsAsync();

        /// <summary>
        /// 访问次数按action统计 自增
        /// </summary>
        /// <param name="action"></param>
        Task IncActionStatsAsync(string controller, string action);

        /// <summary>
        /// 获取action统计
        /// </summary>
        /// <returns></returns>
        Task<List<KeyValueDto<long>>> GetActionStatsAsync();

        /// <summary>
        /// 今日访问次数按ip统计 自增
        /// </summary>
        /// <param name="ip"></param>
        Task IncTodayIpStatsAsync(string ip);

        /// <summary>
        /// 获取今日ip统计
        /// </summary>
        /// <returns></returns>
        Task<List<KeyValueDto<long>>> GetTodayIpStatsAsync();

        /// <summary>
        /// 今日访问次数按action统计 自增
        /// </summary>
        /// <param name="action"></param>
        Task IncTodayActionStatsAsync(string controller, string action);

        /// <summary>
        /// 获取今日action统计
        /// </summary>
        /// <returns></returns>
        Task<List<KeyValueDto<long>>> GetTodayActionStatsAsync();

        /// <summary>
        ///  总访问量 自增
        /// </summary>
        Task IncTotalStatsAsync();

        /// <summary>
        /// 总访问量
        /// </summary>
        /// <returns></returns>
        Task<long> GetTotalStatsAsync();

        /// <summary>
        /// 今日总访问量 自增
        /// </summary>
        Task IncTodayTotalStatsAsync();

        /// <summary>
        /// 今日总访问量
        /// </summary>
        /// <returns></returns>
        Task<long> GetTodayTotalStatsAsync();

        /// <summary>
        /// 获取一周的总访问量
        /// </summary>
        /// <returns></returns>
        Task<List<KeyValueDto<long>>> GetWeekTotalStatsAsync();
    }
}

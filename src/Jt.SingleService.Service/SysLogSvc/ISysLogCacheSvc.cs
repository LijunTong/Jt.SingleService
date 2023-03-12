using JT.Framework.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT.Framework.Core.IService
{
    public interface ISysLogCacheSvc
    {
        void PushLog(SysLog sysLog);
        List<SysLog> PopLog();

        /// <summary>
        /// 访问次数按ip统计 自增
        /// </summary>
        /// <param name="ip"></param>
        void IncIpStats(string ip);
        /// <summary>
        /// 获取ip统计
        /// </summary>
        /// <returns></returns>
        List<KeyValueDto<long>> GetIpStats();
        /// <summary>
        /// 访问次数按action统计 自增
        /// </summary>
        /// <param name="action"></param>
        void IncActionStats(string controller, string action);
        /// <summary>
        /// 获取action统计
        /// </summary>
        /// <returns></returns>
        List<KeyValueDto<long>> GetActionStats();
        /// <summary>
        /// 今日访问次数按ip统计 自增
        /// </summary>
        /// <param name="ip"></param>
        void IncTodayIpStats(string ip);
        /// <summary>
        /// 获取今日ip统计
        /// </summary>
        /// <returns></returns>
        List<KeyValueDto<long>> GetTodayIpStats();
        /// <summary>
        /// 今日访问次数按action统计 自增
        /// </summary>
        /// <param name="action"></param>
        void IncTodayActionStats(string controller, string action);
        /// <summary>
        /// 获取今日action统计
        /// </summary>
        /// <returns></returns>
        List<KeyValueDto<long>> GetTodayActionStats();
        /// <summary>
        ///  总访问量 自增
        /// </summary>
        void IncTotalStats();
        /// <summary>
        /// 总访问量
        /// </summary>
        /// <returns></returns>
        long GetTotalStats();
        /// <summary>
        /// 今日总访问量 自增
        /// </summary>
        void IncTodayTotalStats();
        /// <summary>
        /// 今日总访问量
        /// </summary>
        /// <returns></returns>
        long GetTodayTotalStats();
        /// <summary>
        /// 获取一周的总访问量
        /// </summary>
        /// <returns></returns>
        List<KeyValueDto<long>> GetWeekTotalStats();
    }
}

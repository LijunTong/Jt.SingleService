using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Cms.Service;
using Jt.Common.Tool.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Jt.Cms.Controllers
{
    [Route("SysLog")]
    [AuthorController]
    public class SysLogController : BaseController
    {
        private ISysLogSvc _service;
        private ISysLogCacheSvc _cacheSvc;

        public SysLogController(ISysLogSvc service, JwtHelper jwtHelper, ISysLogCacheSvc cacheService) : base(jwtHelper)
        {
            _service = service;
            _cacheSvc = cacheService;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        [Action("新增", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Insert([FromBody] SysLog entity)
        {
            entity.CreateTime = DateTime.Now;
            entity.Creater = GetUser()?.Id;
            await _service.InsertAsync(entity);
            return Successed(true);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [Action("修改", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Update([FromBody] SysLog entity)
        {
            entity.UpTime = DateTime.Now;
            entity.Updater = GetUser()?.Id;
            var data = await _service.UpdateAsync(entity);
            return Ok(data);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost("Delete")]
        [Action("删除", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Delete(string id)
        {
            var data = await _service.DeleteAsync(id);
            return Ok(data);
        }

        /// <summary>
        /// 通过id查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("Get")]
        public async Task<ActionResult> Get(string id)
        {
            var data = await _service.GetEntityByIdAsync(id);
            return Ok(data);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("List")]
        public async Task<ActionResult> List()
        {
            var data = await _service.GetAllListAsync();
            return Ok(data);
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("ListPager")]
        [Action("列表", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> ListPager([FromBody] GetLogPagerReq req)
        {
            var data = await _service.GetLogsPagerListAsync(req);
            return Ok(data);
        }

        [HttpPost("GetActionStats")]
        public async Task<ActionResult> GetActionStats()
        {
            var data = await _cacheSvc.GetActionStatsAsync();
            return Successed(data);
        }

        [HttpPost("GetTodayActionStats")]
        public async Task<ActionResult> GetTodayActionStats()
        {
            var data = await _cacheSvc.GetTodayActionStatsAsync();
            return Successed(data);
        }

        [HttpPost("GetIpStats")]
        public async Task<ActionResult> GetIpStats()
        {
            var data = await _cacheSvc.GetIpStatsAsync();
            return Successed(data);
        }

        [HttpPost("GetTodayIpStats")]
        public async Task<ActionResult> GetTodayIpStats()
        {
            var data = await _cacheSvc.GetTodayIpStatsAsync();
            return Successed(data);
        }

        [HttpPost("GetTotalStats")]
        public async Task<ActionResult> GetTotalStats()
        {
            var data = await _cacheSvc.GetTotalStatsAsync();
            return Successed(data);
        }

        [HttpPost("GetTodayTotalStats")]
        public async Task<ActionResult> GetTodayTotalStats()
        {
            var data = await _cacheSvc.GetTodayTotalStatsAsync();
            return Successed(data);
        }

        [HttpPost("GetWeekTotalStats")]
        public async Task<ActionResult> GetWeekTotalStats()
        {
            var data = await _cacheSvc.GetWeekTotalStatsAsync();
            return Successed(data);
        }

        [HttpPost("GetLogType")]
        public async Task<ActionResult> GetLogType()
        {
            await Task.CompletedTask;
            var data = EnumHelper.EnumToList(typeof(EnumLogType));
            return Successed(data);
        }
    }
}

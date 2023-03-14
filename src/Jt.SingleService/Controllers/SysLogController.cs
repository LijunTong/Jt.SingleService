using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Jwt;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Core.Attributes;
using Jt.SingleService.Core.Enums;
using Jt.SingleService.Service.SysLogSvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Jt.SingleService.Service.UserSvc;
using Jt.SingleService.Lib.Utils;

namespace Jt.SingleService.Controllers
{
    [Route("SysLog")]
    [AuthorController]
    public class SysLogController : BaseController
    {
        private ISysLogSvc _service;
        private JwtHelper _jwtHelper;
        private ISysLogCacheSvc _cacheSvc;

        public SysLogController(ISysLogSvc service, JwtHelper jwtHelper, ISysLogCacheSvc cacheService)
        {
            _service = service;
            _jwtHelper = jwtHelper;
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
            entity.Creater = (await _jwtHelper.UserAsync<JwtUser>(GetToken()))?.Id;
            await _service.InsertAsync(entity);
            return Ok(ApiResponse<bool>.GetSucceed(true));
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
            entity.Updater = (await _jwtHelper.UserAsync<JwtUser>(GetToken()))?.Id;
            await _service.UpdateAsync(entity);
            return Ok(ApiResponse<bool>.GetSucceed(true));
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpPost("Delete")]
        [Action("删除", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return Ok(ApiResponse<bool>.GetSucceed(true));
        }

        /// <summary>
        /// 通过id查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("Get")]
        public async Task<ActionResult> Get(string id)
        {
            var data = await _service.GetEntityByIdAsync(id);
            return Ok(ApiResponse<SysLog>.GetSucceed(data));
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("List")]
        public async Task<ActionResult> List()
        {
            var data = await _service.GetAllListAsync();
            return Ok(ApiResponse<List<SysLog>>.GetSucceed(data));
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("ListPager")]
        [Action("列表", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> ListPager([FromQuery] PagerReq pagerReq)
        {
            var data = await _service.GetPagerListAsync(pager: pagerReq);
            PagerOutput pager = new PagerOutput()
            {
                Total = pagerReq.Total,
                Data = data
            };
            return Ok(ApiResponse<PagerOutput>.GetSucceed(pager));
        }

        [HttpPost("GetActionStats")]
        public async Task<ActionResult> GetActionStats()
        {
            var data =await _cacheSvc.GetActionStatsAsync();
            return Successed(data);
        }

        [HttpPost("GetTodayActionStats")]
        public async Task<ActionResult> GetTodayActionStats()
        {
            var data =await _cacheSvc.GetTodayActionStatsAsync();
            return Successed(data);
        }

        [HttpPost("GetIpStats")]
        public async Task<ActionResult> GetIpStats()
        {
            var data =await _cacheSvc.GetIpStatsAsync();
            return Successed(data);
        }

        [HttpPost("GetTodayIpStats")]
        public async Task<ActionResult> GetTodayIpStats()
        {
            var data =await _cacheSvc.GetTodayIpStatsAsync();
            return Successed(data);
        }

        [HttpPost("GetTotalStats")]
        public async Task<ActionResult> GetTotalStats()
        {
            var data =await _cacheSvc.GetTotalStatsAsync();
            return Successed(data);
        }

        [HttpPost("GetTodayTotalStats")]
        public async Task<ActionResult> GetTodayTotalStats()
        {
            var data =await _cacheSvc.GetTodayTotalStatsAsync();
            return Successed(data);
        }

        [HttpPost("GetWeekTotalStats")]
        public async Task<ActionResult> GetWeekTotalStats()
        {
            var data =await _cacheSvc.GetWeekTotalStatsAsync();
            return Successed(data);
        }

        [HttpPost("GetLogType")]
        public async Task<ActionResult> GetLogType()
        {
           await Task.CompletedTask;
            var data = CHelperEnum.EnumToList(typeof(EnumLogType));
            return Successed(data);
        }
    }
}

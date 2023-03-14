using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Jwt;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Core.Attributes;
using Jt.SingleService.Core.Enums;
using Jt.SingleService.Service.CodeTempSvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Jt.SingleService.Lib.Utils;

namespace Jt.SingleService.Controllers
{
    [Route("CodeTemp")]
    [AuthorController]
    public class CodeTempController : BaseController
    {
        private ICodeTempSvc _service;
        private JwtHelper _jwtHelper;
        private readonly CHelperSnowflake _snowflake;

        public CodeTempController(ICodeTempSvc service, JwtHelper jwtHelper, CHelperSnowflake snowflake)
        {
            _service = service;
            _jwtHelper = jwtHelper;
            _snowflake = snowflake;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        [Action("新增", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Insert([FromBody] CodeTemp entity)
        {
            entity.Id = _snowflake.NextId().ToString();
            entity.CreateTime = DateTime.Now;
            entity.Creater = (await _jwtHelper.UserAsync<JwtUser>(GetToken()))?.Id;
            entity.UpTime = DateTime.Now;
            entity.Updater = (await _jwtHelper.UserAsync<JwtUser>(GetToken()))?.Id;
            await _service.InsertAsync(entity);
            return Ok(ApiResponse<bool>.GetSucceed(true));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [Action("修改", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Update([FromBody] CodeTemp entity)
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
            return Ok(ApiResponse<CodeTemp>.GetSucceed(data));
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("List")]
        public async Task<ActionResult> List()
        {
            var data = await _service.GetAllListAsync();
            return Ok(ApiResponse<List<CodeTemp>>.GetSucceed(data));
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

        /// <summary>
        /// 获取方案明细
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetTempsByScheme")]
        public async Task<ActionResult> GetTempsByScheme(string schemeId)
        {
            var data = await _service.GetCodeTempsBySchemeAsync(schemeId);
            return Ok(ApiResponse<List<CodeTemp>>.GetSucceed(data));
        }
    }
}

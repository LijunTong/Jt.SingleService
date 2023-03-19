using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Jwt;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Core.Attributes;
using Jt.SingleService.Core.Enums;
using Jt.SingleService.Service.CodeGenSchemeSvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Jt.SingleService.Lib.Utils;
using Jt.SingleService.Data.Dto;

namespace Jt.SingleService.Controllers
{
    [Route("CodeGenScheme")]
    [AuthorController]
    public class CodeGenSchemeController : BaseController
    {
        private ICodeGenSchemeSvc _service;
        private JwtHelper _jwtHelper;
        private readonly CHelperSnowflake _snowflake;

        public CodeGenSchemeController(ICodeGenSchemeSvc service, JwtHelper jwtHelper, CHelperSnowflake snowflake)
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
        public async Task<ActionResult> Insert([FromBody] CodeGenSchemeDto entity)
        {
            entity.UserId = (await _jwtHelper.UserAsync<JwtUser>(GetToken()))?.Id;
            await _service.InsertSchemeAsync(entity);
            return Ok(ApiResponse<bool>.GetSucceed(true));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [Action("修改", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Update([FromBody] CodeGenScheme entity)
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
            return Ok(ApiResponse<CodeGenScheme>.GetSucceed(data));
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("List")]
        public async Task<ActionResult> List()
        {
            string userId = (await _jwtHelper.UserAsync<JwtUser>(GetToken()))?.Id;
            var data = await _service.GetListByUserIdAsync(userId);
            return Ok(ApiResponse<List<CodeGenScheme>>.GetSucceed(data));
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("ListPager")]
        [Action("列表", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> ListPager([FromQuery] PagerReq pagerReq)
        {
            string userId = (await _jwtHelper.UserAsync<JwtUser>(GetToken()))?.Id;
            var data = await _service.GetPageListByUserIdAsync(pagerReq, userId);
            PagerOutput pager = new PagerOutput()
            {
                Total = pagerReq.Total,
                Data = data
            };
            return Ok(ApiResponse<PagerOutput>.GetSucceed(pager));
        }

        /// <summary>
        /// 查询明细
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetSchemeDetials")]
        public async Task<ActionResult> GetSchemeDetials(string schemeId)
        {
            var data = await _service.GetSchemeDetialsAsync(schemeId);
            return Successed(data);
        }
    }
}

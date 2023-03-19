using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Jwt;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Core.Attributes;
using Jt.SingleService.Core.Enums;
using Jt.SingleService.Service.RoleSvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Jt.SingleService.Data.Dto;
using Jt.SingleService.Service.RoleActionSvc;
using Jt.SingleService.Lib.Utils;

namespace Jt.SingleService.Controllers
{
    [Route("Role")]
    [AuthorController]
    public class RoleController : BaseController
    {
        private IRoleSvc _service;
        private JwtHelper _jwtHelper;
        private IRoleActionSvc _roleActionSvc;
        private readonly CHelperSnowflake _snowflake;


        public RoleController(IRoleSvc service, JwtHelper jwtHelper, IRoleActionSvc roleActionSvc, CHelperSnowflake snowflake)
        {
            _service = service;
            _jwtHelper = jwtHelper;
            _roleActionSvc = roleActionSvc;
            _snowflake = snowflake;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        [Action("新增", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Insert([FromBody] Role entity)
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
        public async Task<ActionResult> Update([FromBody] Role entity)
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
            data.RoleActions = await _roleActionSvc.GetRoleActionsAsync(id);
            return Ok(ApiResponse<Role>.GetSucceed(data));
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("List")]
        public async Task<ActionResult> List()
        {
            var data = await _service.GetAllListAsync();
            return Ok(ApiResponse<List<Role>>.GetSucceed(data));
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
        /// 编辑角色权限
        /// </summary>
        /// <returns></returns>
        [HttpPost("BindRoleActions")]

        [Action("分配权限", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> BindRoleActions([FromBody] RoleActionDto roleActionDto)
        {
            roleActionDto.UserId = (await _jwtHelper.UserAsync<JwtUser>(Request))?.Id;
           await _roleActionSvc.BindRoleActionsAsync(roleActionDto);
            return Successed(true);
        }
    }
}

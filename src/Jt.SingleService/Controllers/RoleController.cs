using Jt.SingleService.Core;
using Jt.SingleService.Data;
using Jt.SingleService.Service;
using Microsoft.AspNetCore.Mvc;

namespace Jt.SingleService.Controllers
{
    [Route("Role")]
    [AuthorController]
    public class RoleController : BaseController
    {
        private IRoleSvc _service;
        private IRoleActionSvc _roleActionSvc;


        public RoleController(IRoleSvc service, JwtHelper jwtHelper, IRoleActionSvc roleActionSvc) : base(jwtHelper)
        {
            _service = service;
            _roleActionSvc = roleActionSvc;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        [Action("新增", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Insert([FromBody] Role entity)
        {
            entity.Creater = GetUser()?.Id;
            entity.Updater = GetUser()?.Id;
            await _service.InsertAsync(entity);
            return Successed(true);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [Action("修改", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Update([FromBody] Role entity)
        {
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
            if (data.Code == ApiReturnCode.Succeed && data.Data != null)
            {
                data.Data.RoleActions = (await _roleActionSvc.GetRoleActionsAsync(id)).Data;
            }

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
        public async Task<ActionResult> ListPager([FromQuery] PagerReq pagerReq)
        {
            var data = await _service.GetPagerListAsync(pager: pagerReq);
            return Ok(data);
        }

        /// <summary>
        /// 编辑角色权限
        /// </summary>
        /// <returns></returns>
        [HttpPost("BindRoleActions")]

        [Action("分配权限", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> BindRoleActions([FromBody] RoleActionDto roleActionDto)
        {
            roleActionDto.UserId = (GetUser())?.Id;
            await _roleActionSvc.BindRoleActionsAsync(roleActionDto);
            return Successed(true);
        }
    }
}

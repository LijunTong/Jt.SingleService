using Jt.SingleService.Core;
using Jt.SingleService.Data;
using Jt.SingleService.Service;
using Microsoft.AspNetCore.Mvc;

namespace Jt.SingleService.Controllers
{
    [Route("CodeDb")]
    [AuthorController]
    public class CodeDbController : BaseController
    {
        private ICodeDbSvc _service;

        public CodeDbController(ICodeDbSvc service, JwtHelper jwtHelper) : base(jwtHelper)
        {
            _service = service;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        [Action("新增", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Insert([FromBody] CodeDb entity)
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
        public async Task<ActionResult> Update([FromBody] CodeDb entity)
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
            var data =await _service.DeleteAsync(id);
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
            string userId = GetUser()?.Id;
            var data = await _service.GetListByUserIdAsync(userId);
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
            string userId = GetUser()?.Id;
            var data = await _service.GetPageListByUserIdAsync(pagerReq, userId);
            return Ok(data);
        }
    }
}

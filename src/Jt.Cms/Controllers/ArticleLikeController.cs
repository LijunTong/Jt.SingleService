using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Cms.Service;
using Microsoft.AspNetCore.Mvc;

namespace Jt.Cms.Controllers
{
    [Route("ArticleLike")]
    public class ArticleLikeController : BaseController
    {
        private readonly IArticleLikeSvc _service;

        public ArticleLikeController(IArticleLikeSvc service, JwtHelper jwtHelper) : base(jwtHelper)
        {
            _service = service;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        [Action("新增", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Insert([FromBody] ArticleLike entity)
        {
            entity.Creater = GetUser()?.Id;
            entity.Updater = GetUser()?.Id;
            await _service.InsertAsync(entity);
            return Ok(ApiResponse<object>.Succeed(true));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [Action("修改", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Update([FromBody] ArticleLike entity)
        {
            entity.Updater = GetUser()?.Id;
            await _service.UpdateAsync(entity);
            return Ok(ApiResponse<object>.Succeed(true));
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
            return Ok(ApiResponse<object>.Succeed(true));
        }

        /// <summary>
        /// 通过id查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("Get")]
        public async Task<ActionResult> Get(string id)
        {
            var data = await _service.GetEntityByIdAsync(id);
            return Ok(ApiResponse<object>.Succeed(data));
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("List")]
        public async Task<ActionResult> List()
        {
            var data = await _service.GetAllListAsync();
            return Ok(ApiResponse<object>.Succeed(data));
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
    }
}

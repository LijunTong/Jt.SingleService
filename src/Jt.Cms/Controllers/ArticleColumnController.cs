using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Cms.Service;
using Microsoft.AspNetCore.Mvc;
namespace Jt.Cms.Controllers
{
    [Route("ArticleColumn")]
    public class ArticleColumnController : BaseController
    {
        private readonly IArticleColumnSvc _service;

        public ArticleColumnController(IArticleColumnSvc service, JwtHelper jwtHelper) : base(jwtHelper)
        {
            _service = service;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        [Action("新增", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Insert([FromBody] ArticleColumn entity)
        {
            entity.Creater = GetUser()?.Id;
            entity.Updater = GetUser()?.Id;
            var data = await _service.InsertAsync(entity);
            return Ok(data);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [Action("修改", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Update([FromBody] ArticleColumn entity)
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
    }
}

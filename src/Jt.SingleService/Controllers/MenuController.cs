using Jt.SingleService.Core;
using Jt.SingleService.Data;
using Jt.SingleService.Service;
using Jt.Common.Tool.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jt.SingleService.Controllers
{
    [Route("Menu")]
    [AuthorController]
    public class MenuController : BaseController
    {
        private IMenuSvc _service;
        private IControllerSvc _controllerSvc;
        private IActionSvc _actionSvc;

        public MenuController(IMenuSvc service, JwtHelper jwtHelper, IControllerSvc controllerSvc, IActionSvc actionSvc) : base(jwtHelper)
        {
            _service = service;
            _controllerSvc = controllerSvc;
            _actionSvc = actionSvc;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        [Action("新增", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Insert([FromBody] Menu entity)
        {
            if ((await _service.IsExistsMenuAsync(entity)).Data)
            {
                return Fail($"名称{entity.Name}已存在");
            }

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
        public async Task<ActionResult> Update([FromBody] Menu entity)
        {
            if ((await _service.IsExistsMenuAsync(entity)).Data)
            {
                return Fail($"名称{entity.Name}已存在");
            }

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
        /// 查询用户树形菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetMenuTree")]

        public async Task<ActionResult> GetMenuTree()
        {
            var user = GetUser();
            var data = await _service.GetBackMenuAsync(user.Id);
            return Ok(data);
        }

        /// <summary>
        /// 查询所有树形菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetMenuTreeWithAction")]

        public async Task<ActionResult> GetMenuTreeWithAction()
        {
            var data = await _service.GetMenuTreeWithActionAsync();
            return Ok(data);
        }

        /// <summary>
        /// 查询动态列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetActions")]

        public async Task<ActionResult> GetActions()
        {
            await Task.CompletedTask;
            var data = EnumHelper.EnumToList(typeof(EnumAction));
            return Ok(data);
        }

        [HttpPost("GetController")]

        public async Task<ActionResult> GetController()
        {
            var data = await _controllerSvc.GetControllersAsync();
            return Ok(data);
        }

        [HttpPost("InitController")]

        [Action("更新权限数", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> InitController()
        {
            await _controllerSvc.InitControllerAsync();
            await _actionSvc.InitActionsAsync();
            return Successed(true);
        }

        /// <summary>
        /// 获取菜单类型
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetMenuType")]
        public async Task<ActionResult> GetMenuType()
        {
            await Task.CompletedTask;
            var data = EnumHelper.EnumToList(typeof(EnumMenuType));
            return Successed(data);
        }

        /// <summary>
        /// 获取前台菜单，允许匿名访问
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("GetFrontMenu")]
        public async Task<ActionResult> GetFrontMenu()
        {
            var data = await _service.GetFrontMenuAsync();
            return Ok(data);
        }

        [HttpPost("GetMenuByPath")]
        public async Task<ActionResult> GetMenuByPath(string path)
        {
            var data = await _service.GetMenuAsync(path);
            return Ok(data);
        }

        [HttpPost("BindController")]
        public async Task<ActionResult> BindController(MenuBindDto menuDto)
        {
            Menu menu = new Menu()
            {
                Path = menuDto.path,
                Controller = menuDto.controller,
                Title = menuDto.title
            };
            await _service.BindMenuAndControllerAsync(menu);
            return Successed(true);
        }
    }
}

using Jt.Cms.Core.Models;
using Jt.Cms.Core.Jwt;
using Jt.Cms.Data.Tables;
using Jt.Cms.Core.Attributes;
using Jt.Cms.Core.Enums;
using Jt.Cms.Service.MenuSvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Jt.Cms.Lib.Utils;
using Jt.Cms.Service.ControllerSvc;
using Jt.Cms.Service.ActionSvc;
using Jt.Cms.Data.Dto;

namespace Jt.Cms.Controllers
{
    [Route("Menu")]
    [AuthorController]
    public class MenuController : BaseController
    {
        private IMenuSvc _service;
        private JwtHelper _jwtHelper;
        private IControllerSvc _controllerSvc;
        private IActionSvc _actionSvc;
        private readonly CHelperSnowflake _snowflake;

        public MenuController(IMenuSvc service, JwtHelper jwtHelper, IControllerSvc controllerSvc, IActionSvc actionSvc, CHelperSnowflake snowflake)
        {
            _service = service;
            _jwtHelper = jwtHelper;
            _controllerSvc = controllerSvc;
            _actionSvc = actionSvc;
            _snowflake = snowflake;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        [Action("新增", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Insert([FromBody] Menu entity)
        {
            if (await _service.IsExistsMenuAsync(entity))
            {
                return Fail($"名称{entity.Name}已存在");
            }
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
        public async Task<ActionResult> Update([FromBody] Menu entity)
        {
            if (await _service.IsExistsMenuAsync(entity))
            {
                return Fail($"名称{entity.Name}已存在");
            }

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
            return Ok(ApiResponse<Menu>.GetSucceed(data));
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("List")]
        public async Task<ActionResult> List()
        {
            var data = await _service.GetAllListAsync();
            return Ok(ApiResponse<List<Menu>>.GetSucceed(data));
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
        /// 查询用户树形菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetMenuTree")]

        public async Task<ActionResult> GetMenuTree()
        {
            var user = await _jwtHelper.UserAsync<JwtUser>(GetToken());
            var data = await _service.GetBackMenuAsync(user.Id);
            return Successed(data);
        }

        /// <summary>
        /// 查询所有树形菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetMenuTreeWithAction")]

        public async Task<ActionResult> GetMenuTreeWithAction()
        {
            var data = await _service.GetMenuTreeWithActionAsync();
            return Successed(data);
        }

        /// <summary>
        /// 查询动态列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetActions")]

        public async Task<ActionResult> GetActions()
        {
            await Task.CompletedTask;
            var data = CHelperEnum.EnumToList(typeof(EnumAction));
            return Successed(data);
        }

        [HttpPost("GetController")]

        public async Task<ActionResult> GetController()
        {
            var data = await _controllerSvc.GetControllersAsync();
            return Successed(data);
        }

        [HttpPost("InitController")]

        [Action("更新权限数", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> InitController()
        {
          await  _controllerSvc.InitControllerAsync();
          await  _actionSvc.InitActionsAsync();
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
            var data = CHelperEnum.EnumToList(typeof(EnumMenuType));
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
            var data =await _service.GetFrontMenuAsync();
            return Successed(data);
        }

        [HttpPost("GetMenuByPath")]
        public async Task<ActionResult> GetMenuByPath(string path)
        {
            var data =await _service.GetMenuAsync(path);
            return Successed(data);
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

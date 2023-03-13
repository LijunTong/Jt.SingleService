using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Jwt;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Core.Attributes;
using Jt.SingleService.Core.Enums;
using Jt.SingleService.Service.UserSvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Jt.SingleService.Service.UserRoleSvc;
using Jt.SingleService.Service.RoleSvc;
using Jt.SingleService.Core.Dto;
using Jt.SingleService.Core.Utils;
using Jt.SingleService.Core.Options;
using Microsoft.Extensions.Options;

namespace Jt.SingleService.Controllers
{
    [Route("User")]
    public class UserController : BaseController
    {
        private readonly IUserSvc _userSvc;
        private readonly JwtHelper _jwtHelper;
         private readonly IUserRoleSvc _userRoleSvc;
         private readonly IUserCacheSvc _userCacheSvc;
        private readonly IRoleSvc _roleSvc;
        private readonly AppSettings _appSettings;


        public UserController(IUserSvc service, JwtHelper jwtHelper, IUserRoleSvc userRoleSvc, IUserCacheSvc userCacheSvc,
            IRoleSvc roleSvc, IOptionsMonitor<AppSettings> setting)
        {
            _userSvc = service;
            _jwtHelper = jwtHelper;
            _userRoleSvc = userRoleSvc;
            _userCacheSvc = userCacheSvc;
            _roleSvc = roleSvc;
            _appSettings = setting.CurrentValue;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        [Action("新增", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Insert([FromBody] User entity)
        {
            entity.CreateTime = DateTime.Now;
            entity.Creater = (await _jwtHelper.UserAsync<JwtUser>(GetToken()))?.Id;
            await _userSvc.InsertAsync(entity);
            return Ok(ApiResponse<bool>.GetSucceed(true));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [Action("修改", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Update([FromBody] User entity)
        {
            entity.UpTime = DateTime.Now;
            entity.Updater = (await _jwtHelper.UserAsync<JwtUser>(GetToken()))?.Id;
            await _userSvc.UpdateAsync(entity);
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
            await _userSvc.DeleteAsync(id);
            return Ok(ApiResponse<bool>.GetSucceed(true));
        }

        /// <summary>
        /// 通过id查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("Get")]
        public async Task<ActionResult> Get(string id)
        {
            var data = await _userSvc.GetEntityByIdAsync(id);
            return Ok(ApiResponse<User>.GetSucceed(data));
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("List")]
        public async Task<ActionResult> List()
        {
            var data = await _userSvc.GetAllListAsync();
            return Ok(ApiResponse<List<User>>.GetSucceed(data));
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("ListPager")]
        [Action("列表", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> ListPager([FromQuery] PagerReq pagerReq)
        {
            var data = await _userSvc.GetPagerListAsync(pager: pagerReq);
            PagerOutput pager = new PagerOutput()
            {
                Total = pagerReq.Total,
                Data = data
            };
            return Ok(ApiResponse<PagerOutput>.GetSucceed(pager));
        }

        [HttpPost("CheckUserName")]
        [AllowAnonymous]
        public async Task<ActionResult> CheckUserName(string userName)
        {
            var data = await _userSvc.CheckUserNameExistsAsync(userName);
            return Successed(data);
        }

        [HttpPost("Register")]

        [AllowAnonymous]
        public async Task<ActionResult> Register(UserDto user)
        {

            var exists =await _userSvc.CheckUserNameExistsAsync(user.UserName);
            if (exists)
            {
                return Fail("用户名已存在");
            }
            User registerUser = new()
            {
                UserName = user.UserName,
                Password = CHelperMD5.EncryptMD5(user.Password),
                RegisterTime = DateTime.Now,
                Status = 0
            };
            var result =  await _userSvc.RegisterAsync(registerUser);
            return Ok(result);
        }

        [HttpPost("Login")]

        [AllowAnonymous]
        public async Task<ActionResult> Login(UserDto user)
        {
            var exists = await _userSvc.CheckUserNameExistsAsync(user.UserName);
            if (!exists)
            {
                return Fail("用户名不存在");
            }
            var curUser = await _userSvc.GetUserByNameAsync(user.UserName);
            if (curUser.Status == 1)
            {
                return Fail("账户已锁定");
            }
            if (CHelperMD5.EncryptMD5(user.Password) != curUser.Password)
            {
                return Fail("密码不正确");
            }
            var roles = await _roleSvc.GetRolesAsync(curUser.Id);
            JwtUser userInfo = new JwtUser
            {
                Id = curUser.Id,
                UserName = curUser.UserName,
                Roles = roles
            };

            string accessToken = await _jwtHelper.TokenAsync(userInfo);
            string refreshToken = _jwtHelper.RefreshToken();
            await _userCacheSvc.SetRefreshTokenAsync(curUser.UserName, refreshToken, TimeSpan.FromDays(_appSettings.Jwt.RefreshTokenExpirationDays));
            await _userCacheSvc.SetTokenAsync(curUser.UserName, accessToken, TimeSpan.FromMinutes(_appSettings.Jwt.TokenExpirationMins));
            curUser.LoginTime = DateTime.Now;
            await _userSvc.UpdateAsync(curUser);
            return Successed(new { accessToken, refreshToken, userInfo = curUser });
        }

        [HttpPost("Logout")]
        [AllowAnonymous]
        public async Task<ActionResult> Logout()
        {
            var user = await _jwtHelper.UserAsync<JwtUser>(GetToken());
            if (user == null)
            {
                return Successed(true);
            }
          await  _userCacheSvc.RemoveRefreshTokenAsync(user.UserName);
            return Successed(true);
        }

        [HttpPost("RefreshToken")]
        [AllowAnonymous]
        public async Task<ActionResult> RefreshToken()
        {
            var user = await _jwtHelper.UserAsync<JwtUser>(GetToken());
            if (user == null || ! (await _userCacheSvc.ExistsRefreshTokenAsync(user.UserName)))
            {
                return Ok(ApiResponse<bool>.GetFail(ApiReturnCode.UnAuth));
            }
            string accessToken = await _jwtHelper.TokenAsync(user);
            await _userCacheSvc.SetTokenAsync(user.UserName, accessToken, TimeSpan.FromMinutes(_appSettings.Jwt.TokenExpirationMins));
            return Successed(accessToken);
        }

        [HttpPost("GetUserInfo")]

        public async Task<ActionResult> GetUserInfo(string userId)
        {
            var curUser = await _userSvc.GetEntityByIdAsync(userId);
            return Successed(curUser);
        }

        [HttpPost("EditPassword")]

        [Action("修改密码", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> EditPassword(string userId, string oldPwd, string newPwd)
        {
            var curUser = await _userSvc.GetEntityByIdAsync(userId);
            if (curUser.Password != CHelperMD5.EncryptMD5(oldPwd))
            {
                return Fail("旧密码不正确");
            }
            curUser.Password = CHelperMD5.EncryptMD5(newPwd);
            await _userSvc.UpdateAsync(curUser);
            return Successed(curUser);
        }

        /// <summary>
        /// 绑定角色
        /// </summary>
        /// <param name="userRoleDto"></param>
        /// <returns></returns>
        [HttpPost("BindUserRole")]

        [Action("分配角色", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> BindUserRole(UserRoleDto userRoleDto)
        {
            await _userRoleSvc.BindUserRoleAsync(userRoleDto);
            return Successed(true);
        }
    }
}

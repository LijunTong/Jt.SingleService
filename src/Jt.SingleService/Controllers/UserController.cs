using Jt.SingleService.Core;
using Jt.SingleService.Data;
using Jt.SingleService.Service;
using Jt.Common.Tool.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq.Expressions;

namespace Jt.SingleService.Controllers
{
    [Route("User")]
    [AuthorController]
    public class UserController : BaseController
    {
        private readonly IUserSvc _userSvc;
        private readonly IUserRoleSvc _userRoleSvc;
        private readonly IUserCacheSvc _userCacheSvc;
        private readonly IRoleSvc _roleSvc;
        private readonly AppSettings _appSettings;
        private readonly IFileSvc _fileSvc;


        public UserController(IUserSvc service, JwtHelper jwtHelper, IUserRoleSvc userRoleSvc, IUserCacheSvc userCacheSvc,
            IRoleSvc roleSvc, IOptionsMonitor<AppSettings> setting, IFileSvc fileSvc) : base(jwtHelper)
        {
            _userSvc = service;
            _userRoleSvc = userRoleSvc;
            _userCacheSvc = userCacheSvc;
            _roleSvc = roleSvc;
            _appSettings = setting.CurrentValue;
            _fileSvc = fileSvc;
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost("Insert")]
        [Action("新增", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Insert([FromBody] User entity)
        {
            entity.Creater = GetUser()?.Id;
            entity.Updater = GetUser()?.Id;
            await _userSvc.InsertAsync(entity);
            return Ok(ApiResponse<object>.Succeed(true));
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [Action("修改", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> Update([FromBody] User entity)
        {
            entity.Updater = GetUser()?.Id;
            await _userSvc.UpdateAsync(entity);
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
            await _userSvc.DeleteAsync(id);
            return Ok(ApiResponse<object>.Succeed(true));
        }

        /// <summary>
        /// 通过id查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("Get")]
        public async Task<ActionResult> Get(string id)
        {
            var data = await _userSvc.GetUserAsync(id);
            return Ok(data);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("List")]
        public async Task<ActionResult> List()
        {
            var data = await _userSvc.GetAllListAsync();
            return Ok(ApiResponse<object>.Succeed(data));
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("ListPager")]
        [Action("列表", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> ListPager([FromQuery] GetPagerListReq pagerReq)
        {
            var data = await _userSvc.GetUserPagerAsync(pagerReq);
            return Ok(data);
        }

        [HttpPost("CheckUserName")]
        [AllowAnonymous]
        public async Task<ActionResult> CheckUserName(string userName)
        {
            var data = await _userSvc.CheckUserNameExistsAsync(userName);
            return Ok(data);
        }

        [HttpPost("Register")]

        [AllowAnonymous]
        public async Task<ActionResult> Register(UserLoginReq user)
        {

            var exists = await _userSvc.CheckUserNameExistsAsync(user.UserName);
            if (exists.Data)
            {
                return Fail("用户名已存在");
            }
            User registerUser = new()
            {
                UserName = user.UserName,
                Password = user.Password.ToMD5(),
                RegisterTime = DateTime.Now,
                Status = 0
            };
            var result = await _userSvc.RegisterAsync(registerUser);
            return Ok(result);
        }

        [HttpPost("Login")]

        [AllowAnonymous]
        public async Task<ActionResult> Login(UserLoginReq user)
        {
            var exists = await _userSvc.CheckUserNameExistsAsync(user.UserName);
            if (!exists.Data)
            {
                return Fail("用户名不存在");
            }
            var curUser = await _userSvc.GetUserByNameAsync(user.UserName);
            if (curUser.Data.Status == 1)
            {
                return Fail("账户已锁定");
            }
            if (user.Password.ToMD5() != curUser.Data.Password)
            {
                return Fail("密码不正确");
            }
            var roles = await _roleSvc.GetRolesAsync(curUser.Data.Id);
            JwtUser userInfo = new JwtUser
            {
                Id = curUser.Data.Id,
                UserName = curUser.Data.UserName,
                Roles = roles.Data.JoinSeparator(x => x.Id, ","),
            };

            string accessToken = await _jwtHelper.TokenAsync(userInfo);
            string refreshToken = _jwtHelper.RefreshToken();
            await _userCacheSvc.SetRefreshTokenAsync(curUser.Data.UserName, refreshToken, TimeSpan.FromDays(_appSettings.Jwt.RefreshTokenExpirationDays));
            await _userCacheSvc.SetTokenAsync(curUser.Data.UserName, accessToken, TimeSpan.FromMinutes(_appSettings.Jwt.TokenExpirationMins));
            curUser.Data.LoginTime = DateTime.Now;
            await _userSvc.UpdateAsync(curUser.Data);
            return Successed(new { accessToken, refreshToken, userInfo = userInfo });
        }

        [HttpPost("Logout")]
        [AllowAnonymous]
        public async Task<ActionResult> Logout()
        {
            var user = GetUser();
            if (user == null)
            {
                return Successed(true);
            }
            await _userCacheSvc.RemoveRefreshTokenAsync(user.UserName);
            return Successed(true);
        }

        [HttpPost("RefreshToken")]
        [AllowAnonymous]
        public async Task<ActionResult> RefreshToken()
        {
            var user = GetUser();
            if (user == null || !(await _userCacheSvc.ExistsRefreshTokenAsync(user.UserName)))
            {
                return Ok(ApiResponse<object>.Fail(ApiReturnCode.UnLogin, "请先登录"));
            }
            string accessToken = await _jwtHelper.TokenAsync(user);
            await _userCacheSvc.SetTokenAsync(user.UserName, accessToken, TimeSpan.FromMinutes(_appSettings.Jwt.TokenExpirationMins));
            return Successed(accessToken);
        }

        [HttpPost("GetUserInfo")]

        public async Task<ActionResult> GetUserInfo(string userId)
        {
            var curUser = await _userSvc.GetUserInfoAsync(userId);
            return Ok(curUser);
        }

        [HttpPost("EditPassword")]

        [Action("修改密码", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> EditPassword(string userId, string oldPwd, string newPwd)
        {
            var curUser = await _userSvc.GetEntityByIdAsync(userId);
            if (curUser.Data.Password != oldPwd.ToMD5())
            {
                return Fail("旧密码不正确");
            }
            curUser.Data.Password = newPwd.ToMD5();
            var data = await _userSvc.UpdateAsync(curUser.Data);
            return Ok(data);
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

        [HttpPost("UploadAvatar")]
        public async Task<ActionResult> UploadAvatar(IFormFile file)
        {
            string userId = Guid.NewGuid().ToString().Substring(0, 6);
            var path = await _fileSvc.UploadAvatarAsync(file, userId + "_" + file.FileName);
            return Ok(path);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateAvatar")]
        [Action("修改", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> UpdateAvatar(User entity)
        {
            entity.UpTime = DateTime.Now;
            entity.Updater = GetUser()?.Id;
            Expression<Func<User, object>>[] updatedProperties = {
                    p => p.Avatar,
                };
            var data = await _userSvc.UpdateFieldsAsync(entity, updatedProperties);
            return Ok(data);
        }
    }
}

using Jt.Cms.Core.Enums;
using Jt.Cms.Core.Models;
using Jt.Cms.Data.Tables;
using Jt.Cms.Lib.Utils;
using Jt.Cms.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using Jt.Cms.Lib.DI;
using Jt.Cms.Data.Dto;
using Jt.Cms.Lib.Extensions;

namespace Jt.Cms.Service.UserSvc
{
    public class UserSvc : BaseSvc<User>, IUserSvc, ITransientInterface
    {
        private readonly IUserRepo _repository;
        private readonly IUserRoleRepo _userRoleRepo;
        private readonly IRoleRepo _roleRepo;
        private readonly CHelperSnowflake _snowflake;

        public UserSvc(IUserRepo repository, IUserRoleRepo userRoleRepo, IRoleRepo roleRepo, CHelperSnowflake snowflake) : base(repository)
        {
            _repository = repository;
            _userRoleRepo = userRoleRepo;
            _roleRepo = roleRepo;
            _snowflake = snowflake;
        }

        public async Task<bool> CheckUserNameExistsAsync(string userName)
        {
            return await _repository.GetUserByNameAsync(userName) != null;
        }

        public async Task<User> GetUserByNameAsync(string userName)
        {
            return await _repository.GetUserByNameAsync(userName);
        }

        public async Task<ApiResponse<bool>> RegisterAsync(User user)
        {
            Role role = await _roleRepo.GetFirstAsync(x => x.Code == EnumRole.User.ToString());
            if (role == null)
            {
                return ApiResponse<bool>.GetFail(ApiReturnCode.OperationFail, "½ÇÉ«²»´æÔÚ");
            }

            using (var tran = await _repository.BeginTransactionAsync())
            {
                user.Id = _snowflake.NextId().ToString();
                user.CreateTime = DateTime.Now;
                user.Creater = "";
                user.Updater = "";
                user.UpTime = DateTime.Now;
                await _repository.InsertAsync(user);
                await _repository.SaveAsync();
                UserRole userRole = new UserRole
                {
                    Id = _snowflake.NextId().ToString(),
                    UserId = user.Id,
                    RoleId = role.Id,
                    CreateTime = DateTime.Now,
                    Creater = "",
                    UpTime = DateTime.Now,
                    Updater = ""
                };
                await _userRoleRepo.UseTransactionAsync(tran.GetDbTransaction());
                await _userRoleRepo.InsertAsync(userRole);
                await _userRoleRepo.SaveAsync();

                tran.Commit();
            }

            return ApiResponse<bool>.GetSucceed(true);
        }

        public async Task<GetUserInfoOutput> GetUserInfoAsync(string id)
        {
            var user = await _repository.GetByIdAsync(id);
            return user.ObjValueCopy<User, GetUserInfoOutput>();
        }
    }
}

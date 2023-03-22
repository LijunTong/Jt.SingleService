using Jt.SingleService.Core.Enums;
using Jt.SingleService.Core.Models;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Lib.Utils;
using Jt.SingleService.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using Jt.SingleService.Lib.DI;
using Jt.SingleService.Data.Dto;
using Jt.SingleService.Lib.Extensions;
using Jt.SingleService.Data.Dto.User.Output;
using Jt.SingleService.Data.Dto.User.Req;

namespace Jt.SingleService.Service.UserSvc
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

        public async Task<ApiResponse<GetPagerListOutput>> GetUserAsync(string id)
        {
            var user = await _repository.GetUserAsync(id);
            GetPagerListOutput output = user.ObjValueCopy<User, GetPagerListOutput>();
            return ApiResponse<GetPagerListOutput>.GetSucceed(output);
        }

        public async Task<ApiResponse<PagerOutput>> GetUserPagerAsync(GetPagerListReq req)
        {
            var users = await _repository.GetPagerListAsync(req);
            List<GetPagerListOutput> listOutputs = users.ObjsValueCopy<User, GetPagerListOutput>();
            PagerOutput pagerOutput = new PagerOutput
            {
                Total = req.Total,
                Data = listOutputs
            };
            return ApiResponse<PagerOutput>.GetSucceed(pagerOutput);
        }
    }
}

using Jt.SingleService.Core;
using Jt.SingleService.Data;
using Jt.Common.Tool.DI;
using Jt.Common.Tool.Extension;
using Microsoft.EntityFrameworkCore.Storage;

namespace Jt.SingleService.Service
{
    public class UserSvc : BaseSvc<User>, IUserSvc, ITransientDIInterface
    {
        private readonly IUserRepo _repository;
        private readonly IUserRoleRepo _userRoleRepo;
        private readonly IRoleRepo _roleRepo;
        private readonly IIDSvc _snowflake;

        public UserSvc(IUserRepo repository, IUserRoleRepo userRoleRepo, IRoleRepo roleRepo, IIDSvc snowflake) : base(repository)
        {
            _repository = repository;
            _userRoleRepo = userRoleRepo;
            _roleRepo = roleRepo;
            _snowflake = snowflake;
        }

        public async Task<ApiResponse<bool>> CheckUserNameExistsAsync(string userName)
        {
            var data = await _repository.GetUserByNameAsync(userName) != null;
            return ApiResponse<bool>.Succeed(data);
        }

        public async Task<ApiResponse<User>> GetUserByNameAsync(string userName)
        {
            var data = await _repository.GetUserByNameAsync(userName);
            return ApiResponse<User>.Succeed(data);
        }

        public async Task<ApiResponse<bool>> RegisterAsync(User user)
        {
            Role role = await _roleRepo.GetFirstAsync(x => x.Code == EnumRole.User.ToString());
            if (role == null)
            {
                return ApiResponse<bool>.Fail(ApiReturnCode.OperationFail, "½ÇÉ«²»´æÔÚ");
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

            return ApiResponse<bool>.Succeed(true);
        }

        public async Task<ApiResponse<GetUserInfoOutput>> GetUserInfoAsync(string id)
        {
            var user = await _repository.GetByIdAsync(id);
            var data = user.CopyValue<User, GetUserInfoOutput>();
            return ApiResponse<GetUserInfoOutput>.Succeed(data);
        }

        public async Task<ApiResponse<GetPagerListOutput>> GetUserAsync(string id)
        {
            var user = await _repository.GetUserAsync(id);
            GetPagerListOutput output = user.CopyValue<User, GetPagerListOutput>();
            return ApiResponse<GetPagerListOutput>.Succeed(output);
        }

        public async Task<ApiResponse<PagerOutput<GetPagerListOutput>>> GetUserPagerAsync(GetPagerListReq req)
        {
            var users = await _repository.GetPagerListAsync(req);
            List<GetPagerListOutput> listOutputs = users.CopyValue<User, GetPagerListOutput>();
            PagerOutput<GetPagerListOutput> pagerOutput = new PagerOutput<GetPagerListOutput>
            {
                Total = req.Total,
                Data = listOutputs
            };
            return ApiResponse<PagerOutput<GetPagerListOutput>>.Succeed(pagerOutput);
        }
    }
}

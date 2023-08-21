using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class UserRoleSvc : BaseSvc<UserRole>, IUserRoleSvc, ITransientDIInterface
    {
        private readonly IUserRoleRepo _repository;
        private readonly IIDSvc _snowflake;

        public UserRoleSvc(IUserRoleRepo repository, IIDSvc snowflake) : base(repository)
        {
            _repository = repository;
            _snowflake = snowflake;
        }

        public async Task BindUserRoleAsync(UserRoleDto userRoleDto)
        {
            if (userRoleDto != null)
            {
                await _repository.DeleteAsync(x => x.UserId == userRoleDto.UserId);
                List<UserRole> userRoles = new List<UserRole>();
                userRoleDto.RoleIds.ForEach(x =>
                {
                    userRoles.Add(new UserRole
                    {
                        Id = _snowflake.NextId().ToString(),
                        UserId = userRoleDto.UserId,
                        RoleId = x,
                        CreateTime = DateTime.Now,
                        Creater = "",
                        UpTime = DateTime.Now,
                        Updater = ""
                    });
                });
                await _repository.InsertListAsync(userRoles);
                await _repository.SaveAsync();
            }
        }

        public async Task<ApiResponse< List<UserRole>>> GetUserRolesAsync(string userId)
        {
            var data = await _repository.GetListAsync(x => x.UserId == userId);
            return ApiResponse<List<UserRole>>.Succeed(data);
        }
    }
}

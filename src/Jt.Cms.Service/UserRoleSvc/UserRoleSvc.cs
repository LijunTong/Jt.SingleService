using Jt.Cms.Data.Dto;
using Jt.Cms.Data.Tables;
using Jt.Cms.Data.Repositories.Interface;
using Jt.Cms.Service.UserRoleSvc;
using Jt.Cms.Lib.DI;
using Jt.Cms.Lib.Utils;

namespace Jt.Cms.Service.UserSvc
{
    public class UserRoleSvc : BaseSvc<UserRole>, IUserRoleSvc, ITransientInterface
    {
        private readonly IUserRoleRepo _repository;
        private readonly CHelperSnowflake _snowflake;

        public UserRoleSvc(IUserRoleRepo repository, CHelperSnowflake snowflake) : base(repository)
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

        public async Task<List<UserRole>> GetUserRolesAsync(string userId)
        {
            return await _repository.GetListAsync(x => x.UserId == userId);
        }
    }
}

using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Dto;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.UserRoleSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class UserRoleSvc : BaseSvc<UserRole>, IUserRoleSvc, ITransientInterface
    {
        private readonly IUserRoleRepo _repository;

        public UserRoleSvc(IUserRoleRepo repository) : base(repository)
        {
            _repository = repository;
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

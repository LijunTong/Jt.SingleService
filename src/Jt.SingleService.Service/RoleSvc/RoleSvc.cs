using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.RoleSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class RoleSvc : BaseSvc<Role>, IRoleSvc, ITransientInterface
    {
        private readonly IRoleRepo _repository;
        private readonly IUserRoleRepo _userRoleRepo;

        public RoleSvc(IRoleRepo repository, IUserRoleRepo userRoleRepo) : base(repository)
        {
            _repository = repository;
            _userRoleRepo = userRoleRepo;
        }

        public Task<Role> GetRoleAsync(string code)
        {
            return _repository.GetFirstAsync(x => x.Code == code);
        }

        public async Task<List<Role>> GetRolesAsync(string userId)
        {
            var userRoles = await _userRoleRepo.GetListAsync(x => x.UserId == userId);
            var roleIds = userRoles.Select(x => x.RoleId);
            return await _repository.GetListAsync(x => roleIds.Contains(x.Id));
        }
    }
}

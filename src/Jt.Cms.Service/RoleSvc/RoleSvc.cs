using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class RoleSvc : BaseSvc<Role>, IRoleSvc, ITransientDIInterface
    {
        private readonly IRoleRepo _repository;
        private readonly IUserRoleRepo _userRoleRepo;

        public RoleSvc(IRoleRepo repository, IUserRoleRepo userRoleRepo) : base(repository)
        {
            _repository = repository;
            _userRoleRepo = userRoleRepo;
        }

        public async Task<ApiResponse<Role>> GetRoleAsync(string code)
        {
            var data = await _repository.GetFirstAsync(x => x.Code == code);
            return ApiResponse<Role>.Succeed(data);
        }

        public async Task<ApiResponse<List<Role>>> GetRolesAsync(string userId)
        {
            var userRoles = await _userRoleRepo.GetListAsync(x => x.UserId == userId);
            var roleIds = userRoles.Select(x => x.RoleId);
            var data = await _repository.GetListAsync(x => roleIds.Contains(x.Id));
            return ApiResponse<List<Role>>.Succeed(data);
        }
    }
}

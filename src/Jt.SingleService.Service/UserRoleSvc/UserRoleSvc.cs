using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.UserRoleSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class UserRoleSvc : BaseSvc<UserRole>, IUserRoleSvc
    {
        private readonly IUserRoleRepo _repository;

        public UserRoleSvc(IUserRoleRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

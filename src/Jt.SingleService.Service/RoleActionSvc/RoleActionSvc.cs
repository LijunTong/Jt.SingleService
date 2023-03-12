using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.RoleActionSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class RoleActionSvc : BaseSvc<RoleAction>, IRoleActionSvc
    {
        private readonly IRoleActionRepo _repository;

        public RoleActionSvc(IRoleActionRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

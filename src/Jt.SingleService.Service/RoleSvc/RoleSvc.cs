using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.RoleSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class RoleSvc : BaseSvc<Role>, IRoleSvc
    {
        private readonly IRoleRepo _repository;

        public RoleSvc(IRoleRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.MenuSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class MenuSvc : BaseSvc<Menu>, IMenuSvc
    {
        private readonly IMenuRepo _repository;

        public MenuSvc(IMenuRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

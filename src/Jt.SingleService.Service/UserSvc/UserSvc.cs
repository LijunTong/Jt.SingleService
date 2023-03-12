using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Service.UserSvc
{
    public class UserSvc : BaseSvc<User>, IUserSvc
    {
        private readonly IUserRepo _repository;

        public UserSvc(IUserRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

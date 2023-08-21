using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class UserFollowSvc : BaseSvc<UserFollow>, IUserFollowSvc, ITransientDIInterface
    {
        private readonly IUserFollowRepo _repository;

        public UserFollowSvc(IUserFollowRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

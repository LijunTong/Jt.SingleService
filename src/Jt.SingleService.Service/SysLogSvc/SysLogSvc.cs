using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.SysLogSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class SysLogSvc : BaseSvc<SysLog>, ISysLogSvc
    {
        private readonly ISysLogRepo _repository;

        public SysLogSvc(ISysLogRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

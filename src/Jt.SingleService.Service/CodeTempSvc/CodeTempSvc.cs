using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.CodeTempSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class CodeTempSvc : BaseSvc<CodeTemp>, ICodeTempSvc
    {
        private readonly ICodeTempRepo _repository;

        public CodeTempSvc(ICodeTempRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

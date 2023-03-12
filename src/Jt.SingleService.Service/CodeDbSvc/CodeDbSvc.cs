using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.CodeDbSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class CodeDbSvc : BaseSvc<CodeDb>, ICodeDbSvc
    {
        private readonly ICodeDbRepo _repository;

        public CodeDbSvc(ICodeDbRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

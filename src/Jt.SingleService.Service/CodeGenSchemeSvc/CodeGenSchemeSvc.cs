using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.CodeGenSchemeSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class CodeGenSchemeSvc : BaseSvc<CodeGenScheme>, ICodeGenSchemeSvc
    {
        private readonly ICodeGenSchemeRepo _repository;

        public CodeGenSchemeSvc(ICodeGenSchemeRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

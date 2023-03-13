using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Service.CodeSchemeDetialsSvc;

namespace Jt.SingleService.Service.UserSvc
{
    public class CodeSchemeDetialsSvc : BaseSvc<CodeSchemeDetials>, ICodeSchemeDetialsSvc, ITransientInterface
    {
        private readonly ICodeSchemeDetialsRepo _repository;

        public CodeSchemeDetialsSvc(ICodeSchemeDetialsRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

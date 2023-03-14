using Jt.SingleService.Data.Tables;
using Jt.SingleService.Data.Repositories.Interface;
using Jt.SingleService.Service.CodeSchemeDetialsSvc;
using Jt.SingleService.Lib.DI;

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

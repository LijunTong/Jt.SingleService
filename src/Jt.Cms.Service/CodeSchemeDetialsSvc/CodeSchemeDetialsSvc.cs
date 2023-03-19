using Jt.Cms.Data.Tables;
using Jt.Cms.Data.Repositories.Interface;
using Jt.Cms.Service.CodeSchemeDetialsSvc;
using Jt.Cms.Lib.DI;

namespace Jt.Cms.Service.UserSvc
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

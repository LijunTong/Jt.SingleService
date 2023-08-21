using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class CodeSchemeDetialsSvc : BaseSvc<CodeSchemeDetials>, ICodeSchemeDetialsSvc, ITransientDIInterface
    {
        private readonly ICodeSchemeDetialsRepo _repository;

        public CodeSchemeDetialsSvc(ICodeSchemeDetialsRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

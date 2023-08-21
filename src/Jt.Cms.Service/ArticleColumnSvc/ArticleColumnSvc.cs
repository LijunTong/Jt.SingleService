using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class ArticleColumnSvc : BaseSvc<ArticleColumn>, IArticleColumnSvc, ITransientDIInterface
    {
        private readonly IArticleColumnRepo _repository;

        public ArticleColumnSvc(IArticleColumnRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

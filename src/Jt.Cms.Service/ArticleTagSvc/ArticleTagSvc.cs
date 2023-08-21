using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class ArticleTagSvc : BaseSvc<ArticleTag>, IArticleTagSvc, ITransientDIInterface
    {
        private readonly IArticleTagRepo _repository;

        public ArticleTagSvc(IArticleTagRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

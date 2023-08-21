using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class ArticleCollectSvc : BaseSvc<ArticleCollect>, IArticleCollectSvc, ITransientDIInterface
    {
        private readonly IArticleCollectRepo _repository;

        public ArticleCollectSvc(IArticleCollectRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

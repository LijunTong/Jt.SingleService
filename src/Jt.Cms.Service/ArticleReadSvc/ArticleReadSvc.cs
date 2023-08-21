using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class ArticleReadSvc : BaseSvc<ArticleRead>, IArticleReadSvc, ITransientDIInterface
    {
        private readonly IArticleReadRepo _repository;

        public ArticleReadSvc(IArticleReadRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

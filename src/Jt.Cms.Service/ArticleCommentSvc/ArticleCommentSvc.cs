using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class ArticleCommentSvc : BaseSvc<ArticleComment>, IArticleCommentSvc, ITransientDIInterface
    {
        private readonly IArticleCommentRepo _repository;

        public ArticleCommentSvc(IArticleCommentRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

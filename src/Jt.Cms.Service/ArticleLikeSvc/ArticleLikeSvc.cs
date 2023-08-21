using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class ArticleLikeSvc : BaseSvc<ArticleLike>, IArticleLikeSvc, ITransientDIInterface
    {
        private readonly IArticleLikeRepo _repository;

        public ArticleLikeSvc(IArticleLikeRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

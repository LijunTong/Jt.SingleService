using Jt.Cms.Data;
using Jt.Common.Tool.DI;

namespace Jt.Cms.Service
{
    public class CommentLikeSvc : BaseSvc<CommentLike>, ICommentLikeSvc, ITransientDIInterface
    {
        private readonly ICommentLikeRepo _repository;

        public CommentLikeSvc(ICommentLikeRepo repository) : base(repository)
        {
            _repository = repository;
        }
    }
}

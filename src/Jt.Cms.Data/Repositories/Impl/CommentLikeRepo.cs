using Jt.Common.Tool.DI;

namespace Jt.Cms.Data
{
    public class CommentLikeRepo : BaseRepo<CommentLike>, ICommentLikeRepo, ITransientDIInterface
    {
        public CommentLikeRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

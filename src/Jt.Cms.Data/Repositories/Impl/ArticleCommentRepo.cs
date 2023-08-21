using Jt.Common.Tool.DI;

namespace Jt.Cms.Data
{
    public class ArticleCommentRepo : BaseRepo<ArticleComment>, IArticleCommentRepo, ITransientDIInterface
    {
        public ArticleCommentRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

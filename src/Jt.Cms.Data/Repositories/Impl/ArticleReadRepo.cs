using Jt.Common.Tool.DI;

namespace Jt.Cms.Data
{
    public class ArticleReadRepo : BaseRepo<ArticleRead>, IArticleReadRepo, ITransientDIInterface
    {
        public ArticleReadRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

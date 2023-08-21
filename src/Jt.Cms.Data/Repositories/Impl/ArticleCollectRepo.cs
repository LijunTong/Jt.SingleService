using Jt.Common.Tool.DI;

namespace Jt.Cms.Data
{
    public class ArticleCollectRepo : BaseRepo<ArticleCollect>, IArticleCollectRepo, ITransientDIInterface
    {
        public ArticleCollectRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

using Jt.Common.Tool.DI;

namespace Jt.Cms.Data
{
    public class ArticleColumnRepo : BaseRepo<ArticleColumn>, IArticleColumnRepo, ITransientDIInterface
    {
        public ArticleColumnRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

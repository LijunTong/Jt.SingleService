using Jt.Common.Tool.DI;

namespace Jt.Cms.Data
{
    public class ArticleTagRepo : BaseRepo<ArticleTag>, IArticleTagRepo, ITransientDIInterface
    {
        public ArticleTagRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

using Jt.Common.Tool.DI;

namespace Jt.Cms.Data
{
    public class ArticleLikeRepo : BaseRepo<ArticleLike>, IArticleLikeRepo, ITransientDIInterface
    {
        public ArticleLikeRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

using Jt.Common.Tool.DI;

namespace Jt.Cms.Data
{
    public class TagRepo : BaseRepo<Tag>, ITagRepo, ITransientDIInterface
    {
        public TagRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

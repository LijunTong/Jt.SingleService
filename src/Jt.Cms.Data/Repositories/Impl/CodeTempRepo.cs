using Jt.Common.Tool.DI;

namespace Jt.Cms.Data
{
    public class CodeTempRepo : BaseRepo<CodeTemp>, ICodeTempRepo, ITransientDIInterface
    {
        public CodeTempRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

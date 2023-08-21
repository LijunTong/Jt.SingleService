using Jt.Common.Tool.DI;

namespace Jt.SingleService.Data
{
    public class CodeTempRepo : BaseRepo<CodeTemp>, ICodeTempRepo, ITransientDIInterface
    {
        public CodeTempRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

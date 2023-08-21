using Jt.Common.Tool.DI;

namespace Jt.SingleService.Data
{
    public class CodeDbRepo : BaseRepo<CodeDb>, ICodeDbRepo, ITransientDIInterface
    {
        public CodeDbRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

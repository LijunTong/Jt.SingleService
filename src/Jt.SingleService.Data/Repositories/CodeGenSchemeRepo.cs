using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Data.Repositories
{
    public class CodeGenSchemeRepo : BaseRepo<CodeGenScheme>, ICodeGenSchemeRepo
    {
        public CodeGenSchemeRepo (MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Data.Repositories
{
    public class CodeSchemeDetialsRepo : BaseRepo<CodeSchemeDetials>, ICodeSchemeDetialsRepo
    {
        public CodeSchemeDetialsRepo (MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

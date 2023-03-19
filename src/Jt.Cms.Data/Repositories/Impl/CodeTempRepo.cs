using Jt.Cms.Data.DbContexts;
using Jt.Cms.Data.Tables;
using Jt.Cms.Data.Repositories.Interface;
using Jt.Cms.Lib.DI;

namespace Jt.Cms.Data.Repositories.Impl
{
    public class CodeTempRepo : BaseRepo<CodeTemp>, ICodeTempRepo, ITransientInterface
    {
        public CodeTempRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

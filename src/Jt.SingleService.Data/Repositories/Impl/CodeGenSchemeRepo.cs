using Jt.SingleService.Data.DbContexts;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Data.Repositories.Interface;
using Jt.SingleService.Lib.DI;
using Microsoft.EntityFrameworkCore;

namespace Jt.SingleService.Data.Repositories.Impl
{
    public class CodeGenSchemeRepo : BaseRepo<CodeGenScheme>, ICodeGenSchemeRepo, ITransientInterface
    {
        public CodeGenSchemeRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<CodeGenScheme> GetCodeGenSchemeAsync(string schemeId)
        {
            return await DbSet.Where(x => x.Id == schemeId)
                             .Include(x => x.CodeSchemeDetials)
                                 .ThenInclude(x => x.CodeTemp)
                             .FirstOrDefaultAsync();
        }
    }
}

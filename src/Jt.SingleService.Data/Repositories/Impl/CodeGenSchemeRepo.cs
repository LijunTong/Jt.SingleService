using Jt.Common.Tool.DI;
using Microsoft.EntityFrameworkCore;

namespace Jt.SingleService.Data
{
    public class CodeGenSchemeRepo : BaseRepo<CodeGenScheme>, ICodeGenSchemeRepo, ITransientDIInterface
    {
        public CodeGenSchemeRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<CodeGenScheme> GetCodeGenSchemeAsync(string schemeId)
        {
            return await DbSet.Where(x => x.Id == schemeId)
                            .Include(x => x.CodeSchemeDetials.Where(o => o.IsDel == 0))
                                .ThenInclude(x => x.CodeTemp)
                            .FirstOrDefaultAsync();
        }
    }
}

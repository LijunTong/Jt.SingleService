using Jt.Common.Tool.DI;
using Jt.SingleService.Lib.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Jt.SingleService.Data
{
    public class CodeSchemeDetialsRepo : BaseRepo<CodeSchemeDetials>, ICodeSchemeDetialsRepo, ITransientDIInterface
    {
        public CodeSchemeDetialsRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<CodeSchemeDetials>> GetSchemeDetialsAsync(string schemeId)
        {
            return await DbSet.Where(x => x.GenSchemeId == schemeId)
                 .Include(x => x.CodeTemp)
                 .Include(x => x.GenSchemeId)
                 .ToListAsync();
        }
    }
}

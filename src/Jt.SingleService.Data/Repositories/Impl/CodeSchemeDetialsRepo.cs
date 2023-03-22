using Jt.SingleService.Data.DbContexts;
using Jt.SingleService.Data.Repositories.Dto;
using Jt.SingleService.Data.Repositories.Interface;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Lib.DI;
using Jt.SingleService.Lib.Extensions;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data.Common;

namespace Jt.SingleService.Data.Repositories.Impl
{
    public class CodeSchemeDetialsRepo : BaseRepo<CodeSchemeDetials>, ICodeSchemeDetialsRepo, ITransientInterface
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

using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Extensions;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Repositories.Dto;
using Jt.SingleService.Core.Tables;
using MySqlConnector;
using System.Data.Common;

namespace Jt.SingleService.Data.Repositories
{
    public class CodeSchemeDetialsRepo : BaseRepo<CodeSchemeDetials>, ICodeSchemeDetialsRepo, ITransientInterface
    {
        public CodeSchemeDetialsRepo (MysqlDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<CodeSchemeDetialsDto>> GetSchemeDetialsAsync(string schemeId)
        {
            string sql = @"SELECT d.*,t.name AS CodeTempName FROM code_scheme_detials AS d 
                        LEFT JOIN code_temp AS t
                        ON d.temp_id = t.id
                        WHERE d.gen_scheme_id = @gen_scheme_id";
            DbParameter[] dbParameters = new DbParameter[]
            {
                new MySqlParameter(){ParameterName = "gen_scheme_id",Value =  schemeId}
            };
            return await DbContext.Database.SqlQueryAsync<CodeSchemeDetialsDto>(sql, dbParameters);
        }
    }
}

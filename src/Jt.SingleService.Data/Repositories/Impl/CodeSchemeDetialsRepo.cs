using Jt.SingleService.Data.DbContexts;
using Jt.SingleService.Data.Repositories.Dto;
using Jt.SingleService.Data.Repositories.Interface;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Lib.DI;
using Jt.SingleService.Lib.Extensions;
using MySqlConnector;
using System.Data.Common;

namespace Jt.SingleService.Data.Repositories.Impl
{
    public class CodeSchemeDetialsRepo : BaseRepo<CodeSchemeDetials>, ICodeSchemeDetialsRepo, ITransientInterface
    {
        public CodeSchemeDetialsRepo(MysqlDbContext dbContext) : base(dbContext)
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

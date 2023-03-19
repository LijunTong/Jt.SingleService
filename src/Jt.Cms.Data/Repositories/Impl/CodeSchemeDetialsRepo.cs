using Jt.Cms.Data.DbContexts;
using Jt.Cms.Data.Repositories.Dto;
using Jt.Cms.Data.Repositories.Interface;
using Jt.Cms.Data.Tables;
using Jt.Cms.Lib.DI;
using Jt.Cms.Lib.Extensions;
using MySqlConnector;
using System.Data.Common;

namespace Jt.Cms.Data.Repositories.Impl
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

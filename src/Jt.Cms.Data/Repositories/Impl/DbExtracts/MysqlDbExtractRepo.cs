using Jt.Cms.Core;
using Jt.Cms.Lib.Extensions;
using Jt.Common.Tool.Helper;
using Microsoft.EntityFrameworkCore;

namespace Jt.Cms.Data
{
    public class MysqlDbExtractRepo : IDbExtractRepo
    {
        string _dbType = "";
        string _dbConnectionString = "";

        public async Task SetDbTypeAsync(string dbType, string connectStr)
        {
            _dbType = dbType;
            _dbConnectionString = connectStr;
            await Task.CompletedTask;
        }
        private DbContext GetDbContext()
        {
            DbContext dbContext = new DefaultMysqlDbContext(_dbConnectionString);
            return dbContext;
        }

        public async Task<List<DbInfo>> GetDataBasesAsync()
        {
            string sql = "SHOW DATABASES";
            return await GetAsync<DbInfo>(sql);
        }

        public async Task<List<DbTableInfo>> GetTableNamesAsync(string dbName)
        {
            string sql = $"select table_name as 'TableName'  from information_schema.tables where table_schema='{dbName}'";
            return await GetAsync<DbTableInfo>(sql);
        }

        public async Task<List<DbFieldInfo>> GetDbFieldsAsync(string dbName, string tableName)
        {
            string sql = @$"SELECT COLUMN_NAME AS 'FieldName',DATA_TYPE AS `FieldDbType`,CHARACTER_MAXIMUM_LENGTH AS `FieldLength`,NUMERIC_PRECISION AS `NumberLength`,NUMERIC_SCALE AS `DecimalPoint`,IS_NULLABLE AS `IsNotNull`, CASE WHEN EXTRA = 'auto_increment' THEN 1 ELSE 0 END AS `IsIncrement`,COLUMN_DEFAULT AS `DefaultValue`,COLUMN_COMMENT AS `FieldDes`
                FROM information_schema.COLUMNS WHERE TABLE_SCHEMA = '{dbName}' AND TABLE_NAME = '{tableName}' ORDER BY ordinal_position";
            var data = await GetAsync<DbFieldInfo>(sql);
            foreach (var item in data)
            {
                item.FieldModelName = NamedHelper.ToPascal(item.FieldName);
                item.FieldModelNameCamel = NamedHelper.ToCamelCase(item.FieldName);
                item.FieldModelType = Constrant.DicMysqlFieldMap[item.FieldDbType];
            }
            return data;
        }

        public async Task<List<string>> GetAsync(string sql)
        {
            DbContext dbContext = GetDbContext();
            var data = await dbContext.Database.SqlQueryAsync<dynamic>(sql);
            List<string> lst = new List<string>();
            foreach (var item in data)
            {
                lst.Add(item);
            }
            return lst;
        }

        public async Task<List<T>> GetAsync<T>(string sql) where T : class, new()
        {
            DbContext dbContext = GetDbContext();
            var data = await dbContext.Database.SqlQueryAsync<T>(sql);
            List<T> lst = new List<T>();
            foreach (var item in data)
            {
                lst.Add(item);
            }
            return lst;
        }

    }
}

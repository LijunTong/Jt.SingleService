using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.Extensions;
using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables.DatabaseEntity;
using Jt.SingleService.Core.Utils;
using Microsoft.EntityFrameworkCore;

namespace Jt.SingleService.Data.Repositories.DbExtracts
{
    public class SqlServerDbExtractRepo : IDbExtractRepo
    {
        string _dbType = "";
        string _dbConnectionString = "";

        public async Task SetDbTypeAsync(string dbType,string connectStr)
        {
            _dbType = dbType;
            _dbConnectionString = connectStr;
            await Task.CompletedTask;
        }
        private DbContext GetDbContext()
        {
            DbContext dbContext = new DefaultSqlServerDbContext(_dbConnectionString);
            return dbContext;
        }

        public async Task<List<DbInfo>> GetDataBasesAsync()
        {
            string sql = "SELECT name as 'DataBase' FROM  master..SysDatabases WHERE name NOT IN ( 'master', 'model', 'msdb', 'tempdb' )";
            return await GetAsync<DbInfo>(sql);
        }

        public async Task<List<DbTableInfo>> GetTableNamesAsync(string dbName)
        {
            string sql = $"SELECT name as 'TableName' FROM {dbName}..sysobjects Where xtype='U' ORDER BY name";
            return await GetAsync<DbTableInfo>(sql);
        }

        public async Task<List<DbFieldInfo>> GetDbFieldsAsync(string dbName, string tableName)
        {
            string sql = @$"USE {dbName};
                SELECT a.name FieldName,b.name FieldDbType,
                (case when (SELECT count(*) FROM sysobjects  WHERE 
                (name in (SELECT name FROM sysindexes  WHERE (id = a.id) AND (indid in  (SELECT indid FROM sysindexkeys  WHERE (id = a.id) AND (colid in  (SELECT colid FROM syscolumns WHERE (id = a.id) AND (name = a.name)))))))  AND (xtype = 'PK'))>0 then 1 else 0 end) IsPrimaryKey,(case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then 1 else 0 end) IsIncrement,  CASE WHEN (charindex('int',b.name)>0) OR (charindex('time',b.name)>0) THEN NULL ELSE  COLUMNPROPERTY(a.id,a.name,'PRECISION') --a.length 
                end as FieldLength, CASE WHEN ((charindex('int',b.name)>0) OR (charindex('time',b.name)>0)) THEN NULL 
                ELSE isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),null) end as DecimalPoint,
                (case when a.isnullable=1 then 'YES' else 'NO' end) IsNotNull,Replace(Replace(IsNull(e.text,''),'(',''),')','') DefaultValue,
                isnull(g.[value], ' ') AS FieldDes FROM  syscolumns a left join systypes b on a.xtype=b.xusertype inner join sysobjects d on a.id=d.id and d.xtype='U' and d.name<>'dtproperties' left join syscomments e on a.cdefault=e.id left join sys.extended_properties g on a.id=g.major_id AND a.colid=g.minor_id 
                Left join sys.extended_properties f on d.id=f.class and f.minor_id=0 where b.name is not NULL and d.name='{tableName}' order by a.id,a.colorder";
            var data = await GetAsync<DbFieldInfo>(sql);
            foreach (var item in data)
            {
                item.FieldModelName = CHelperName.ToPascal(item.FieldName);
                item.FieldModelNameCamel = CHelperName.ToCamelCase(item.FieldName);
                item.FieldModelType = Constrant.DicSqlServerFieldMap[item.FieldDbType];
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

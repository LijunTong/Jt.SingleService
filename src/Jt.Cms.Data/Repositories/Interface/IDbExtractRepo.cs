using Jt.Cms.Data.Tables.DatabaseEntity;

namespace Jt.Cms.Data.Repositories.Interface
{
    public interface IDbExtractRepo
    {
        Task SetDbTypeAsync(string dbType, string connectStr);

        Task<List<DbInfo>> GetDataBasesAsync();

        Task<List<DbTableInfo>> GetTableNamesAsync(string dbName);

        Task<List<DbFieldInfo>> GetDbFieldsAsync(string dbName, string tableName);
    }
}

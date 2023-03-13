﻿using Jt.SingleService.Core.Tables.DatabaseEntity;

namespace Jt.SingleService.Core.Repositories
{
    public interface IDbExtractRepo
    {
        Task SetDbTypeAsync(string dbType, string connectStr);

        Task<List<DbInfo>> GetDataBasesAsync();

        Task<List<DbTableInfo>> GetTableNamesAsync(string dbName);

        Task<List<DbFieldInfo>> GetDbFieldsAsync(string dbName, string tableName);
    }
}
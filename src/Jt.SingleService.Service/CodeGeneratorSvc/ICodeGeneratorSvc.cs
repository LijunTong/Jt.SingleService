﻿using Jt.SingleService.Core;
using Jt.SingleService.Data;
namespace Jt.SingleService.Service
{
    public interface ICodeGeneratorSvc
    {
        Task SetDbTypeAsync(string dbType, string connectStr);

        Task<ApiResponse<List<DbInfo>>> GetDataBasesAsync();

        Task<ApiResponse<List<DbTableInfo>>> GetTableNamesAsync(string dbName);

        Task<ApiResponse<List<DbFieldInfo>>> GetDbFieldsAsync(string dbName, string tableName);

        Task<ApiResponse<string>> CodeGenerateAsync(List<CodeTemp> codeSchemeDetials, CodeTempParamsDto codeTempParams, string fileDir);
    }
}

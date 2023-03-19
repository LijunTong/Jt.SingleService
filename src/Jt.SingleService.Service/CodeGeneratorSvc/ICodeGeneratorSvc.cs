using Jt.SingleService.Data.Dto;
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Data.Tables.DatabaseEntity;

namespace Jt.SingleService.Service.CodeDbSvc
{
    public interface ICodeGeneratorSvc
    {
        Task SetDbTypeAsync(string dbType, string connectStr);

        Task<List<DbInfo>> GetDataBasesAsync();

        Task<List<DbTableInfo>> GetTableNamesAsync(string dbName);

         Task<List<DbFieldInfo>> GetDbFieldsAsync(string dbName, string tableName);

         Task<string> CodeGenerateAsync(List<CodeTemp> codeSchemeDetials, CodeTempParamsDto codeTempParams,string fileDir);
    }
}

using Jt.SingleService.Core.Dto;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Core.Tables.DatabaseEntity;

namespace Jt.SingleService.Service.CodeDbSvc
{
    public interface ICodeGeneratorService
    {
        Task SetDbTypeAsync(string dbType, string connectStr);

        Task<List<DbInfo>> GetDataBasesAsync();

        Task<List<DbTableInfo>> GetTableNamesAsync(string dbName);

         Task<List<DbFieldInfo>> GetDbFieldsAsync(string dbName, string tableName);

         Task<string> CodeGenerateAsync(List<CodeTemp> codeSchemeDetials, CodeTempParamsDto codeTempParams,string fileDir);
    }
}

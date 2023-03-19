using Jt.Cms.Data.Dto;
using Jt.Cms.Data.Tables;
using Jt.Cms.Data.Tables.DatabaseEntity;

namespace Jt.Cms.Service.CodeDbSvc
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

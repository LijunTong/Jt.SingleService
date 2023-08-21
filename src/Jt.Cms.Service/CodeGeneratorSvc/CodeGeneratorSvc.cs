using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Common.Tool.DI;
using Jt.Cms.Lib.Utils;
using Jt.Common.Tool.Helper;

namespace Jt.Cms.Service
{
    public class CodeGeneratorSvc : ICodeGeneratorSvc, ITransientDIInterface
    {
        private IDbExtractRepo _dbExtractRepo;

        public CodeGeneratorSvc()
        {
        }

        public async Task SetDbTypeAsync(string dbType, string connectStr)
        {
            if (dbType.ToLower() == EnumDbProvider.MySql.ToString().ToLower())
            {
                _dbExtractRepo = new MysqlDbExtractRepo();
            }
            else if (dbType.ToLower() == EnumDbProvider.SqlServer.ToString().ToLower())
            {
                _dbExtractRepo = new SqlServerDbExtractRepo();
            }
            else if (dbType.ToLower() == EnumDbProvider.PostgreSQL.ToString().ToLower())
            {
                _dbExtractRepo = new PostgreSQLDbExtractRepo();
            }
            else
            {
                throw new Exception("暂不支持" + dbType);
            }
            await _dbExtractRepo.SetDbTypeAsync(dbType, connectStr);
        }

        public async Task<ApiResponse<List<DbInfo>>> GetDataBasesAsync()
        {
            var data = await _dbExtractRepo.GetDataBasesAsync();
            return ApiResponse<List<DbInfo>>.Succeed(data);
        }

        public async Task<ApiResponse<List<DbFieldInfo>>> GetDbFieldsAsync(string dbName, string tableName)
        {
            var data = await _dbExtractRepo.GetDbFieldsAsync(dbName, tableName);
            return ApiResponse<List<DbFieldInfo>>.Succeed(data);
        }

        public async Task<ApiResponse<List<DbTableInfo>>> GetTableNamesAsync(string dbName)
        {
            var data = await _dbExtractRepo.GetTableNamesAsync(dbName);
            return ApiResponse<List<DbTableInfo>>.Succeed(data);
        }

        public async Task<ApiResponse<string>> CodeGenerateAsync(List<CodeTemp> codeTemps, CodeTempParamsDto codeTempParams, string fileDir)
        {
            fileDir = Path.Combine(fileDir, Guid.NewGuid().ToString());
            ResSystemHelper.Mkdirs(fileDir);
            foreach (var temp in codeTempParams.Temps)
            {
                var item = codeTemps.Where(x => x.Id == temp.TempId).FirstOrDefault();
                if (item == null)
                {
                    throw new Exception($"模板{temp.FileName}不存在");
                }
                string key = Guid.NewGuid().ToString();
                if (string.IsNullOrWhiteSpace(temp.FileName))
                {
                    throw new Exception($"模板{item.Name}对应的文件名称为空");
                }
                try
                {
                    await Task.Run(() =>
                    {
                        string content = CHelperRazorEngine.CodeGenerateRazorEngine(key, item.TempContent, codeTempParams);
                        FileInfoHelper.WriteToFile(fileDir, temp.FileName, content);
                    });
                }
                catch (Exception ex)
                {
                    string msg = ex.Message.ToString();
                    FileInfoHelper.WriteToFile(fileDir, temp.FileName + ".log", msg);
                }
            }

            string data = "";
            if (ZipHelper.Zip(fileDir))
            {
                data = fileDir + ".zip";
            }

            return ApiResponse<string>.Succeed(data);
        }
    }
}

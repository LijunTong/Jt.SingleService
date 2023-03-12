using Jt.SingleService.Core.Dto;
using Jt.SingleService.Core.Enums;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using Jt.SingleService.Core.Tables.DatabaseEntity;
using Jt.SingleService.Core.Utils;
using Jt.SingleService.Data.Repositories.DbExtracts;
using Jt.SingleService.Service.CodeDbSvc;
using JT.Framework.Core.IRepository;
using JT.Framework.Core.IService;
using JT.Framework.Core.Model;
using JT.Framework.Core.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Jt.SingleService.Service.CodeGeneratorSvc
{
    public class CodeGeneratorService : ICodeGeneratorService
    {
        private IDbExtractRepo _dbExtractRepo;

        public CodeGeneratorService()
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

        public async Task<List<DbInfo>> GetDataBasesAsync()
        {
            return await _dbExtractRepo.GetDataBasesAsync();
        }

        public Task<List<DbFieldInfo>> GetDbFieldsAsync(string dbName, string tableName)
        {
            var data = _dbExtractRepo.GetDbFieldsAsync(dbName, tableName);
            return data;
        }

        public Task<List<DbTableInfo>> GetTableNamesAsync(string dbName)
        {
            return _dbExtractRepo.GetTableNamesAsync(dbName);
        }

        public async Task<string> CodeGenerateAsync(List<CodeTemp> codeTemps, CodeTempParamsDto codeTempParams, string fileDir)
        {
            fileDir = Path.Combine(fileDir, Guid.NewGuid().ToString());
            CHelperResSystem.Mkdirs(fileDir);
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
                    string content = CHelperRazorEngine.CodeGenerateRazorEngine(key, item.TempContent, codeTempParams);
                    ChelperFileInfo.SaveToFile(fileDir, temp.FileName, content);
                }
                catch (Exception ex)
                {
                    string msg = ex.Message.ToString();
                    ChelperFileInfo.SaveToFile(fileDir, temp.FileName + ".log", msg);
                }
            }
            await Task.CompletedTask;
            if (CHelperZip.Zip(fileDir))
            {
                return fileDir + ".zip";
            }
            else
            {
                return "";
            }
        }
    }
}

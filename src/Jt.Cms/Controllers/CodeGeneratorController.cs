using Jt.Cms.Core;
using Jt.Cms.Data;
using Jt.Cms.Service;
using Jt.Common.Tool.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Jt.Cms.Controllers
{
    [AuthorController]
    [Route("CodeGenerator")]
    public class CodeGeneratorController : BaseController
    {
        private readonly ICodeGeneratorSvc _codeGeneratorSvc;
        private readonly ICodeGeneratorCacheSvc _codeGeneratorCacheSvc;
        private readonly ICodeTempSvc _codeTempSvc;
        private readonly ICodeGenSchemeSvc _codeGenSchemeSvc;
        private readonly string _fileDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeTemp");

        public CodeGeneratorController(ICodeGeneratorSvc codeGeneratorService, ICodeGeneratorCacheSvc codeGeneratorCache, ICodeTempSvc codeTempService, ICodeGenSchemeSvc codeGenSchemeService, JwtHelper jwtHelper) : base(jwtHelper)
        {
            _codeGeneratorSvc = codeGeneratorService;
            _codeGeneratorCacheSvc = codeGeneratorCache;
            _codeTempSvc = codeTempService;
            _codeGenSchemeSvc = codeGenSchemeService;
        }

        [HttpPost("SetDb")]
        [Action("连接", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> SetDb(string dbType, string connectString)
        {
            var user = GetUser();
            await _codeGeneratorCacheSvc.SetDbTypeAsync(user.UserName, dbType, TimeSpan.FromDays(1));
            await _codeGeneratorCacheSvc.SetDbConnectStrAsync(user.UserName, connectString, TimeSpan.FromDays(1));
            return Successed(true);
        }

        [HttpPost("GetDataBases")]
        public async Task<ActionResult> GetDataBases()
        {
            await SetDbTypeAsync();
            try
            {
                var data = await _codeGeneratorSvc.GetDataBasesAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        [HttpPost("GetTableNames")]
        public async Task<ActionResult> GetTableNames(string dbName)
        {
            await SetDbTypeAsync();
            try
            {
                var data = await _codeGeneratorSvc.GetTableNamesAsync(dbName);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        [HttpPost("GetDbFields")]
        public async Task<ActionResult> GetDbFields(string dbName, string tableName)
        {
            await SetDbTypeAsync();
            var data = await _codeGeneratorSvc.GetDbFieldsAsync(dbName, tableName);
            var result = new { ClassName = NamedHelper.ToPascal(tableName), DbFields = data.Data };
            return Successed(result);
        }


        [HttpPost("CodeGenerator")]
        [Action("生成", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> CodeGenerator(CodeTempParamsDto codeTempParams)
        {
            await SetDbTypeAsync();
            var codeTemps = await _codeTempSvc.GetCodeTempsBySchemeAsync(codeTempParams.CodeSchemeId);
            try
            {
                var data = await _codeGeneratorSvc.CodeGenerateAsync(codeTemps.Data, codeTempParams, _fileDir);
                Console.WriteLine(data.Data);
                return Successed(ResSystemHelper.GetFileName(data.Data));
            }
            catch (Exception ex)
            {
                return Fail(ex.Message);
            }
        }

        [HttpPost("GetCodeFile")]
        public async Task<ActionResult> GetCodeFile(string codeFileName)
        {
            return await Task.Run(() =>
            {
                string filePath = Path.Combine(_fileDir, codeFileName);
                FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                FileStreamResult streamResult = new FileStreamResult(fileStream, new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream"));
                streamResult.FileDownloadName = ResSystemHelper.GetFileName(filePath);
                return streamResult;
            });
        }

        [HttpPost("GetSchemeDetials")]
        public async Task<ActionResult> GetSchemeDetials(string schemeId, string className, string tableName)
        {
            var data = await _codeGenSchemeSvc.GetCodeGenSchemeAsync(schemeId);
            if (data.Code == ApiReturnCode.Succeed)
            {
                foreach (var item in data.Data.CodeSchemeDetials)
                {
                    item.FileName = item.FileName.Replace("{ClassName}", className).Replace("{TableName}", tableName);
                }
            }
            
            return Ok(data);
        }

        [HttpPost("GetDbProvider")]
        public async Task<ActionResult> GetDbProvider()
        {
            await Task.CompletedTask;
            var data = EnumHelper.GetEnumItem(typeof(EnumDbProvider));
            return Successed(data);
        }

        [NonAction]
        private async Task SetDbTypeAsync()
        {
            var user = GetUser();
            await _codeGeneratorSvc.SetDbTypeAsync(await _codeGeneratorCacheSvc.GetDbTypeAsync(user.UserName), await _codeGeneratorCacheSvc.GetDbConnectStrAsync(user.UserName));
        }
    }
}

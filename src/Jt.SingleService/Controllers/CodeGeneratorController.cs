using Jt.SingleService.Core.Attributes;
using Jt.SingleService.Data.Dto;
using Jt.SingleService.Core.Enums;
using Jt.SingleService.Core.Jwt;
using Jt.SingleService.Lib.Utils;
using Jt.SingleService.Service.CodeDbSvc;
using Jt.SingleService.Service.CodeGeneratorSvc;
using Jt.SingleService.Service.CodeGenSchemeSvc;
using Jt.SingleService.Service.CodeTempSvc;
using Microsoft.AspNetCore.Mvc;

namespace Jt.SingleService.Controllers
{
    [AuthorController]
    [Route("CodeGenerator")]
    public class CodeGeneratorController : BaseController
    {
        private readonly ICodeGeneratorSvc _codeGeneratorSvc;
        private readonly ICodeGeneratorCacheSvc _codeGeneratorCacheSvc;
        private readonly ICodeTempSvc _codeTempSvc;
        private readonly ICodeGenSchemeSvc _codeGenSchemeSvc;
        private JwtHelper _jwtHelper;
        private readonly string _fileDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeTemp");

        public CodeGeneratorController(ICodeGeneratorSvc codeGeneratorService, ICodeGeneratorCacheSvc codeGeneratorCache, ICodeTempSvc codeTempService, ICodeGenSchemeSvc codeGenSchemeService, JwtHelper jwtHelper)
        {
            _codeGeneratorSvc = codeGeneratorService;
            _codeGeneratorCacheSvc = codeGeneratorCache;
            _codeTempSvc = codeTempService;
            _codeGenSchemeSvc = codeGenSchemeService;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("SetDb")]
        [Action("连接", EnumActionType.AuthorizeAndLog)]
        public async Task<ActionResult> SetDb(string dbType, string connectString)
        {
            var user = await _jwtHelper.UserAsync<JwtUser>(GetToken());
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
                return Successed(data);
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
                return Successed(data);
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
            var result = new { ClassName = CHelperName.ToPascal(tableName), DbFields = data };
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
                string data = await _codeGeneratorSvc.CodeGenerateAsync(codeTemps, codeTempParams, _fileDir);
                Console.WriteLine(data);
                return Successed(CHelperResSystem.GetFileName(data));
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
                streamResult.FileDownloadName = CHelperResSystem.GetFileName(filePath);
                return streamResult;
            });
        }

        [HttpPost("GetSchemeDetials")]
        public async Task<ActionResult> GetSchemeDetials(string schemeId, string className, string tableName)
        {
            var data = await _codeGenSchemeSvc.GetCodeGenSchemeAsync(schemeId);
            foreach (var item in data.CodeSchemeDetials)
            {
                item.FileName = item.FileName.Replace("{ClassName}", className).Replace("{TableName}", tableName);
            }
            return Successed(data.CodeSchemeDetials);
        }

        [HttpPost("GetDbProvider")]
        public async Task<ActionResult> GetDbProvider()
        {
            await Task.CompletedTask;
            var data = CHelperEnum.GetEnumItem(typeof(EnumDbProvider));
            return Successed(data);
        }

        [NonAction]
        private async Task SetDbTypeAsync()
        {
            var user = await _jwtHelper.UserAsync<JwtUser>(GetToken());
            await _codeGeneratorSvc.SetDbTypeAsync(await _codeGeneratorCacheSvc.GetDbTypeAsync(user.UserName), await _codeGeneratorCacheSvc.GetDbConnectStrAsync(user.UserName));
        }
    }
}

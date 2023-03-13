using Jt.SingleService.Core.Dto;
using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Repositories.Dto;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Service.CodeGenSchemeSvc
{
    public interface ICodeGenSchemeSvc : IBaseSvc<CodeGenScheme>
    {
        Task InsertSchemeAsync(CodeGenScheme entity, List<CodeTempDto> temps);

        Task<List<CodeGenScheme>> GetListByUserIdAsync(string userId);

        Task<List<CodeGenScheme>> GetPageListByUserIdAsync(PagerReq pagerEntity, string userId);

        Task<List<CodeSchemeDetialsDto>> GetSchemeDetialsAsync(string schemeId);
    }
}
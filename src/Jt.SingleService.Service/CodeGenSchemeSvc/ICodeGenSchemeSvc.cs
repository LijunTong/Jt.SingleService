using Jt.SingleService.Data.Dto;
using Jt.SingleService.Core.Models;
using Jt.SingleService.Data.Repositories.Dto;
using Jt.SingleService.Data.Tables;

namespace Jt.SingleService.Service.CodeGenSchemeSvc
{
    public interface ICodeGenSchemeSvc : IBaseSvc<CodeGenScheme>
    {
        Task InsertSchemeAsync(CodeGenSchemeDto dto);

        Task<List<CodeGenScheme>> GetListByUserIdAsync(string userId);

        Task<List<CodeGenScheme>> GetPageListByUserIdAsync(PagerReq pagerEntity, string userId);

        Task<List<CodeSchemeDetialsDto>> GetSchemeDetialsAsync(string schemeId);
    }
}
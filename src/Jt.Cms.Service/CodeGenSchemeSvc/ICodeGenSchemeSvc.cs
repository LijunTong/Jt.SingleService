using Jt.Cms.Data.Dto;
using Jt.Cms.Core.Models;
using Jt.Cms.Data.Repositories.Dto;
using Jt.Cms.Data.Tables;

namespace Jt.Cms.Service.CodeGenSchemeSvc
{
    public interface ICodeGenSchemeSvc : IBaseSvc<CodeGenScheme>
    {
        Task InsertSchemeAsync(CodeGenSchemeDto dto);

        Task<List<CodeGenScheme>> GetListByUserIdAsync(string userId);

        Task<List<CodeGenScheme>> GetPageListByUserIdAsync(PagerReq pagerEntity, string userId);

        Task<List<CodeSchemeDetialsDto>> GetSchemeDetialsAsync(string schemeId);
    }
}
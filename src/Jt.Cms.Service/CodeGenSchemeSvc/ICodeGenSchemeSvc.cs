using Jt.Cms.Core;
using Jt.Cms.Data;
namespace Jt.Cms.Service
{
    public interface ICodeGenSchemeSvc : IBaseSvc<CodeGenScheme>
    {
        Task<ApiResponse<bool>> InsertSchemeAsync(CodeGenSchemeDto dto);

        Task<ApiResponse<List<CodeGenScheme>>> GetListByUserIdAsync(string userId);

        Task<ApiResponse<PagerOutput<CodeGenScheme>>> GetPageListByUserIdAsync(PagerReq pagerEntity, string userId);

        Task<ApiResponse<List<CodeSchemeDetials>>> GetSchemeDetialsAsync(string schemeId);

        Task<ApiResponse<CodeGenScheme>> GetCodeGenSchemeAsync(string schemeId);
    }
}
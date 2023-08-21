using Jt.SingleService.Core;
using Jt.SingleService.Data;
namespace Jt.SingleService.Service
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
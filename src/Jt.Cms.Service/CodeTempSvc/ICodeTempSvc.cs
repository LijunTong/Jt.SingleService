using Jt.Cms.Core;
using Jt.Cms.Data;
namespace Jt.Cms.Service
{
    public interface ICodeTempSvc : IBaseSvc<CodeTemp>
    {
        Task<ApiResponse<List<CodeTemp>>> GetListByUserIdAsync(string userId);

        Task<ApiResponse<List<CodeTemp>>> GetCodeTempsBySchemeAsync(string schemeId);

        Task<ApiResponse<PagerOutput<CodeTemp>>> GetPageListByUserIdAsync(PagerReq pagerReq, string userId);
    }
}
using Jt.SingleService.Core;
using Jt.SingleService.Data;
namespace Jt.SingleService.Service
{
    public interface ICodeTempSvc : IBaseSvc<CodeTemp>
    {
        Task<ApiResponse<List<CodeTemp>>> GetListByUserIdAsync(string userId);

        Task<ApiResponse<List<CodeTemp>>> GetCodeTempsBySchemeAsync(string schemeId);

        Task<ApiResponse<PagerOutput<CodeTemp>>> GetPageListByUserIdAsync(PagerReq pagerReq, string userId);
    }
}
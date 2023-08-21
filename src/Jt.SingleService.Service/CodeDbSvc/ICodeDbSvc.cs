using Jt.SingleService.Core;
using Jt.SingleService.Data;
namespace Jt.SingleService.Service
{
    public interface ICodeDbSvc : IBaseSvc<CodeDb>
    {
        Task<ApiResponse<List<CodeDb>>> GetListByUserIdAsync(string userId);

        Task<ApiResponse<PagerOutput<CodeDb>>> GetPageListByUserIdAsync(PagerReq pagerEntity, string userId);
    }
}
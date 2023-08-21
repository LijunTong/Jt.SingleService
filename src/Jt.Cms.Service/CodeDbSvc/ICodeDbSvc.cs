using Jt.Cms.Core;
using Jt.Cms.Data;
namespace Jt.Cms.Service
{
    public interface ICodeDbSvc : IBaseSvc<CodeDb>
    {
        Task<ApiResponse<List<CodeDb>>> GetListByUserIdAsync(string userId);

        Task<ApiResponse<PagerOutput<CodeDb>>> GetPageListByUserIdAsync(PagerReq pagerEntity, string userId);
    }
}
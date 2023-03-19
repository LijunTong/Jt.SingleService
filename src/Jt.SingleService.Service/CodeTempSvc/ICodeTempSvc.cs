using Jt.SingleService.Core.Models;
using Jt.SingleService.Data.Tables;

namespace Jt.SingleService.Service.CodeTempSvc
{
    public interface ICodeTempSvc : IBaseSvc<CodeTemp>
    {
        Task<List<CodeTemp>> GetListByUserIdAsync(string userId);

        Task<List<CodeTemp>> GetCodeTempsBySchemeAsync(string schemeId);

        Task<List<CodeTemp>> GetPageListByUserIdAsync(PagerReq pagerReq, string userId);
    }
}
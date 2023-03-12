using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Service.CodeTempSvc
{
    public interface ICodeTempSvc : IBaseSvc<CodeTemp>
    {
        Task<List<CodeTemp>> GetListByUserIdAsync(int userId);

        Task<List<CodeTemp>> GetCodeTempsBySchemeAsync(int schemeId);

        Task<List<CodeTemp>> GetPageListByUserIdAsync(PagerReq pagerReq, int userId);
    }
}
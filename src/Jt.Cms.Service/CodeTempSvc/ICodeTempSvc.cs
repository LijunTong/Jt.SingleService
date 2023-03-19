using Jt.Cms.Core.Models;
using Jt.Cms.Data.Tables;

namespace Jt.Cms.Service.CodeTempSvc
{
    public interface ICodeTempSvc : IBaseSvc<CodeTemp>
    {
        Task<List<CodeTemp>> GetListByUserIdAsync(string userId);

        Task<List<CodeTemp>> GetCodeTempsBySchemeAsync(string schemeId);

        Task<List<CodeTemp>> GetPageListByUserIdAsync(PagerReq pagerReq, string userId);
    }
}
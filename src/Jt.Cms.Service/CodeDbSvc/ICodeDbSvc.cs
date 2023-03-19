using Jt.Cms.Core.Models;
using Jt.Cms.Data.Tables;

namespace Jt.Cms.Service.CodeDbSvc
{
    public interface ICodeDbSvc : IBaseSvc<CodeDb>
    {
        Task<List<CodeDb>> GetListByUserIdAsync(string userId);

        Task<List<CodeDb>> GetPageListByUserIdAsync(PagerReq pagerEntity, string userId);
    }
}
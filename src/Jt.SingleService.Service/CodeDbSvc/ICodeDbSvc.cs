using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Service.CodeDbSvc
{
    public interface ICodeDbSvc : IBaseSvc<CodeDb>
    {
        Task<List<CodeDb>> GetListByUserIdAsync(string userId);

        Task<List<CodeDb>> GetPageListByUserIdAsync(PagerReq pagerEntity, string userId);
    }
}
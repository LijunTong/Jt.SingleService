using Jt.SingleService.Core.Tables;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Repositories.Dto;
using Jt.SingleService.Core.Dto;

namespace Jt.SingleService.Core.Repositories
{
    public interface ICodeSchemeDetialsRepo : IBaseRepo<CodeSchemeDetials>
    {
        Task<List<CodeSchemeDetialsDto>> GetSchemeDetialsAsync(int schemeId);
    }
}
using Jt.SingleService.Data.Tables;
using Jt.SingleService.Data.Repositories.Dto;
using Jt.SingleService.Data.Dto;

namespace Jt.SingleService.Data.Repositories.Interface
{
    public interface ICodeSchemeDetialsRepo : IBaseRepo<CodeSchemeDetials>
    {
        Task<List<CodeSchemeDetialsDto>> GetSchemeDetialsAsync(string schemeId);
    }
}
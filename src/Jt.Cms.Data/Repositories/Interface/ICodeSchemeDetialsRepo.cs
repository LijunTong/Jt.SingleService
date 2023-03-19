using Jt.Cms.Data.Tables;
using Jt.Cms.Data.Repositories.Dto;
using Jt.Cms.Data.Dto;

namespace Jt.Cms.Data.Repositories.Interface
{
    public interface ICodeSchemeDetialsRepo : IBaseRepo<CodeSchemeDetials>
    {
        Task<List<CodeSchemeDetialsDto>> GetSchemeDetialsAsync(string schemeId);
    }
}
namespace Jt.Cms.Data
{
    public interface ICodeSchemeDetialsRepo : IBaseRepo<CodeSchemeDetials>
    {
        Task<List<CodeSchemeDetials>> GetSchemeDetialsAsync(string schemeId);
    }
}
namespace Jt.SingleService.Data
{
    public interface ICodeSchemeDetialsRepo : IBaseRepo<CodeSchemeDetials>
    {
        Task<List<CodeSchemeDetials>> GetSchemeDetialsAsync(string schemeId);
    }
}
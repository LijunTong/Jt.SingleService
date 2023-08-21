namespace Jt.SingleService.Data
{
    public interface ICodeGenSchemeRepo : IBaseRepo<CodeGenScheme>
    {
        Task<CodeGenScheme> GetCodeGenSchemeAsync(string schemeId);
    }
}
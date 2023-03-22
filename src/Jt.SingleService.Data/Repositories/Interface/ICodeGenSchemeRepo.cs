using Jt.SingleService.Data.Tables;

namespace Jt.SingleService.Data.Repositories.Interface
{
    public interface ICodeGenSchemeRepo : IBaseRepo<CodeGenScheme>
    {
        Task<CodeGenScheme> GetCodeGenSchemeAsync(string schemeId);
    }
}
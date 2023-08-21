using Jt.SingleService.Core;

namespace Jt.SingleService.Service
{
    public interface ICodeGeneratorCacheSvc : IBaseCacheSvc
    {
        //代码生成工具
        Task SetDbTypeAsync(string userName, string dbType, TimeSpan expiresIn);

        Task<string> GetDbTypeAsync(string userName);

        Task SetDbConnectStrAsync(string userName, string connectStr, TimeSpan expiresIn);

        Task<string> GetDbConnectStrAsync(string userName);
    }
}

using Jt.SingleService.Core.Cache;
using Jt.SingleService.Lib.DI;

namespace Jt.SingleService.Service.CodeGeneratorSvc
{
    public class CodeGeneratorCacheSvc : BaseCacheSvc, ICodeGeneratorCacheSvc, ITransientInterface
    {
        ICacheSvc _cacheSvc;

        readonly string KeyDbType = "DbType";
        readonly string KeyDbConnectStr = "DbConStr";

        public CodeGeneratorCacheSvc(ICacheSvc CacheSvc)
        {
            _cacheSvc = CacheSvc;
        }

        public async Task SetDbTypeAsync(string userName, string dbType, TimeSpan expiresIn)
        {
            string key = MergeKey(userName, KeyDbType);
            await _cacheSvc.AddAsync(key, dbType, expiresIn);
        }
        public async Task<string> GetDbTypeAsync(string userName)
        {
            string key = MergeKey(userName, KeyDbType);
            return await _cacheSvc.GetAsync<string>(key);
        }

        public async Task SetDbConnectStrAsync(string userName, string connectStr, TimeSpan expiresIn)
        {
            string key = MergeKey(userName, KeyDbConnectStr);
            await _cacheSvc.AddAsync(key, connectStr, expiresIn);
        }

        public async Task<string> GetDbConnectStrAsync(string userName)
        {
            string key = MergeKey(userName, KeyDbConnectStr);
            return await _cacheSvc.GetAsync<string>(key);
        }
    }
}

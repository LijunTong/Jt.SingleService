using JT.Framework.Core.IService;
using JT.Framework.Library.CommonService;
using System;

namespace Jt.SingleService.Service.CodeGeneratorSvc
{
    public class CodeGeneratorCacheSvc : BaseCacheService, ICodeGeneratorCacheService
    {
        ICacheService _cacheService;

        readonly string KeyDbType = "DbType";
        readonly string KeyDbConnectStr = "DbConStr";

        public CodeGeneratorCacheSvc(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public void SetDbType(string userName, string dbType, TimeSpan expiresIn)
        {
            string key = MergeKey(userName, KeyDbType);
            _cacheService.Add(key, dbType, expiresIn);
        }
        public string GetDbType(string userName)
        {
            string key = MergeKey(userName, KeyDbType);
            return _cacheService.Get<string>(key);
        }

        public void SetDbConnectStr(string userName, string connectStr, TimeSpan expiresIn)
        {
            string key = MergeKey(userName, KeyDbConnectStr);
            _cacheService.Add(key, connectStr, expiresIn);
        }

        public string GetDbConnectStr(string userName)
        {
            string key = MergeKey(userName, KeyDbConnectStr);
            return _cacheService.Get<string>(key);
        }
    }
}

using JT.Framework.Core.IService;
using JT.Framework.Library.CommonService;
using System;

namespace JT.Framework.Core.Service
{
    public class UserCacheSvc: BaseCacheService, IUserCacheSvc
    {
        ICacheService _cacheService;

        readonly string KeyRefreshToken = "KeyRefreshToken";
        readonly string KeyToken = "KeyToken";


        public UserCacheSvc(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public bool ExistsRefreshToken(string userName)
        {
            string key = MergeKey(userName, KeyRefreshToken);
            return _cacheService.Exists(key);
        }

        public void SetRefreshToken(string userName, string refreshToken, TimeSpan expiresIn)
        {
            string key = MergeKey(userName, KeyRefreshToken);
            _cacheService.Add(key, refreshToken, expiresIn);
        }

        public string GetRefreshToken(string userName)
        {
            string key = MergeKey(userName, KeyRefreshToken);
            return _cacheService.Get<string>(key);
        }

        public void RemoveRefreshToken(string userName)
        {
            string key = MergeKey(userName, KeyRefreshToken);
            _cacheService.Remove(key);
        }

        public void SetToken(string userName, string token, TimeSpan expiresIn)
        {
            string key = MergeKey(userName, KeyToken);
            _cacheService.Add(key, token, expiresIn);
        }

        public string GetToken(string userName)
        {
            string key = MergeKey(userName, KeyToken);
            return _cacheService.Get<string>(key);
        }

    }
}

using Jt.SingleService.Core;
using Jt.Common.Tool.DI;

namespace Jt.SingleService.Service
{
    public class UserCacheSvc : BaseCacheSvc, IUserCacheSvc, ITransientDIInterface
    {
        ICacheSvc _cacheSvc;

        readonly string KeyRefreshToken = "KeyRefreshToken";
        readonly string KeyToken = "KeyToken";


        public UserCacheSvc(ICacheSvc CacheSvc)
        {
            _cacheSvc = CacheSvc;
        }

        public async Task<bool> ExistsRefreshTokenAsync(string userName)
        {
            string key = MergeKey(userName, KeyRefreshToken);
            return await _cacheSvc.ExistsAsync(key);
        }

        public async Task SetRefreshTokenAsync(string userName, string refreshToken, TimeSpan expiresIn)
        {
            string key = MergeKey(userName, KeyRefreshToken);
            await _cacheSvc.AddAsync(key, refreshToken, expiresIn);
        }

        public async Task<string> GetRefreshTokenAsync(string userName)
        {
            string key = MergeKey(userName, KeyRefreshToken);
            return await _cacheSvc.GetAsync<string>(key);
        }

        public async Task RemoveRefreshTokenAsync(string userName)
        {
            string key = MergeKey(userName, KeyRefreshToken);
            await _cacheSvc.RemoveAsync(key);
        }

        public async Task SetTokenAsync(string userName, string token, TimeSpan expiresIn)
        {
            string key = MergeKey(userName, KeyToken);
            await _cacheSvc.AddAsync(key, token, expiresIn);
        }

        public async Task<string> GetTokenAsync(string userName)
        {
            string key = MergeKey(userName, KeyToken);
            return await _cacheSvc.GetAsync<string>(key);
        }

    }
}

using Jt.Cms.Core;

namespace Jt.Cms.Service
{
    public interface IUserCacheSvc : IBaseCacheSvc
    {
        //RefreshToken
        Task SetRefreshTokenAsync(string userName, string refreshToken, TimeSpan expiresIn);

        Task<string> GetRefreshTokenAsync(string userName);

        Task RemoveRefreshTokenAsync(string userName);

        Task<bool> ExistsRefreshTokenAsync(string userName);

        //token
        Task SetTokenAsync(string userName, string token, TimeSpan expiresIn);

        Task<string> GetTokenAsync(string userName);

    }
}

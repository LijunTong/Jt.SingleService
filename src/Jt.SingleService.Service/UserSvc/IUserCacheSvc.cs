using System;

namespace JT.Framework.Core.IService
{
    public interface IUserCacheSvc: IBaseCacheService
    {
        //RefreshToken
        void SetRefreshToken(string userName, string refreshToken, TimeSpan expiresIn);
        string GetRefreshToken(string userName);
        void RemoveRefreshToken(string userName);
        bool ExistsRefreshToken(string userName);

        //token
        void SetToken(string userName, string token, TimeSpan expiresIn);
        string GetToken(string userName);

    }
}

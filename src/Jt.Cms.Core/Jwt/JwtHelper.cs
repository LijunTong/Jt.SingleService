using Jt.Cms.Lib.Extensions;
using Jt.Cms.Core.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Jt.Cms.Lib.DI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Jt.Cms.Core.Jwt
{
    public class JwtHelper : ISingletonInterface
    {
        private readonly AppSettings _settings;
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;

        public JwtHelper(IOptions<AppSettings> setting,
                         JwtSecurityTokenHandler jwtSecurityTokenHandler)
        {
            _settings = setting.Value;
            _jwtSecurityTokenHandler = jwtSecurityTokenHandler;
        }

        public async Task<string> TokenAsync<T>(T user)
        {
            var chaims = GetClaims(user);
            var signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Jwt.SecurityKey));
            var signingCredentials = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _settings.Jwt.Issuer,
                audience: _settings.Jwt.Audience,
                claims: chaims,
                expires: DateTime.Now.AddMinutes(_settings.Jwt.TokenExpirationMins),
                signingCredentials: signingCredentials
                );
            await Task.CompletedTask;
            return _jwtSecurityTokenHandler.WriteToken(token);
        }

        public async Task<T> UserAsync<T>(string token)
        {
            await Task.CompletedTask;
            if (token.IsNullOrWhiteSpace())
            {
                return default;
            }
            Type t = typeof(T);
            T user = (T)Activator.CreateInstance(t);
            var jwt = _jwtSecurityTokenHandler.ReadJwtToken(token);
            foreach (var item in jwt.Claims)
            {
                var prop = t.GetProperty(item.Type);
                if(prop != null) 
                {
                    prop.SetValue(user, item.Value);
                }
            }
            return user;
        }

        public async Task<T> UserAsync<T>(HttpRequest request)
        {
            string authorization = request.Headers["Authorization"];
            if (authorization == null)
            {
                return default;
            }
            string token = authorization.Replace(JwtBearerDefaults.AuthenticationScheme, "").Replace(" ", "");
            
            if (token.IsNullOrWhiteSpace())
            {
                return default;
            }
            Type t = typeof(T);
            T user = (T)Activator.CreateInstance(t);
            var jwt = _jwtSecurityTokenHandler.ReadJwtToken(token);
            foreach (var item in jwt.Claims)
            {
                var prop = t.GetProperty(item.Type);
                if (prop != null)
                {
                    prop.SetValue(user, item.Value);
                }
            }
            await Task.CompletedTask;
            return user;
        }

        private List<Claim> GetClaims<T>(T user)
        {
            var claims = new List<Claim>();
            foreach (var item in user.GetType().GetProperties())
            {
                claims.Add(new Claim(item.Name, item.GetValue(user).ToString()));
            }
            return claims;
        }

        public string RefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

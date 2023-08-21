using Jt.Common.Tool.DI;
using Jt.Common.Tool.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jt.SingleService.Core
{
    public class JwtHelper : ISingletonDIInterface
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

        public T User<T>(string token)
        {
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
            return user;
        }

        public T User<T>(HttpRequest request)
        {
            string authorization = request.Headers["Authorization"];
            if (authorization == null)
            {
                return default;
            }
            string token = authorization.Replace(JwtBearerDefaults.AuthenticationScheme, "").Replace(" ", "");
            return User<T>(token);
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

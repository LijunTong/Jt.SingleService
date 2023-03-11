using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.Options
{
    public class AppSettings
    {
        public static string Position = "AppSettings";

        public string AppName { get; set; }

        public string AppVersion { get; set; }
       
        public RedisConfig Redis { get; set; }

        public class RedisConfig
        {
            public string Instance { get; set; }

            public string RedisConnectString { get; set; }

            public int Database { get; set; }
        }

        public JwtConfig Jwt { get; set; }

        public class JwtConfig
        {
            public string SecurityKey { get; set; }
            
            public string Issuer { get; set; }

            public string Audience { get; set; }

            public double TokenExpirationMins { get; set; }

            public double RefreshTokenExpirationDays { get; set; }
        }
    }
}

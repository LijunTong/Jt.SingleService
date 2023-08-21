namespace Jt.Cms.Core
{
    public class AppSettings
    {
        public static string Position = "AppSettings";

        public string AppName { get; set; }

        public string AppVersion { get; set; }

        public ConnectionStringsConfig ConnectionStrings { get; set; }

        public class ConnectionStringsConfig
        {
            public string Mysql { get; set; }

            public string Version { get; set; }
        }


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

        public QuartzInfo Quartz { get; set; }

        public class QuartzInfo
        {
            public List<QuartzJob> Jobs { get; set; }
        }

        public class QuartzJob
        {
            public string JobName { get; set; }
            public string Type { get; set; }
            public string Cron { get; set; }
            public bool Enable { get; set; }
        }
    }
}

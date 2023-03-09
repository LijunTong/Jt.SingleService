using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core
{
    public class AppSettings
    {
        public string AppName { get; set; }

        public RedisConfig Redis { get; set; }

        public class RedisConfig
        {
            public string Instance { get; set; }

            public string RedisConnectString { get; set; }

            public int Database { get; set; }
        }
    }
}

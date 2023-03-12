using Jt.SingleService.Core.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jt.SingleService.Core.DbContexts
{
    public class MysqlDbContext : DbContext
    {
        private readonly AppSettings _appSettings;

        public MysqlDbContext(IOptionsMonitor<AppSettings> setting)
        {
            _appSettings = setting.CurrentValue;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_appSettings.ConnectionStrings.Mysql, new MySqlServerVersion(_appSettings.ConnectionStrings.Version));
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            base.OnConfiguring(optionsBuilder);
        }
    }
}

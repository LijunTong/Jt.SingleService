using Jt.Cms.Core.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Jt.Cms.Data.DbContexts
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var mappingInterface = typeof(IEntityTypeConfiguration<>);
            List<Type> types = AppDomain.CurrentDomain
                             .GetAssemblies()
                             .SelectMany(x => x.GetTypes()).Where(type => !String.IsNullOrEmpty(type.Namespace)).Where(x => x.GetInterfaces().Any(y => y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() == mappingInterface)).ToList();
            foreach (Type type in types)
            {
                dynamic entityTypeConfiguration = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(entityTypeConfiguration);
            }

        }
    }
}

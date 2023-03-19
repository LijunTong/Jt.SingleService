using Microsoft.EntityFrameworkCore;

namespace Jt.Cms.Data.DbContexts
{
    public class DefaultSqlServerDbContext : DbContext
    {
        private string _connectString;
        public DefaultSqlServerDbContext(string connectString)
        {
            _connectString = connectString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectString);
        }
    }
}

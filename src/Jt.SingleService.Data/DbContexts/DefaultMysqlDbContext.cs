using Microsoft.EntityFrameworkCore;

namespace Jt.SingleService.Data.DbContexts
{
    public class DefaultMysqlDbContext : DbContext
    {
        private string _connectString;
        public DefaultMysqlDbContext(string connectString)
        {
            _connectString = connectString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectString, new MySqlServerVersion("MySQL5.7.26"));
        }
    }
}

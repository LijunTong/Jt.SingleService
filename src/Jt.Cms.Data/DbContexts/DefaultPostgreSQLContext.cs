using Microsoft.EntityFrameworkCore;

namespace Jt.Cms.Data
{
    public class DefaultPostgreSQLContext : DbContext
    {
        private string _connectString;
        public DefaultPostgreSQLContext(string connectString)
        {
            _connectString = connectString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectString);
        }
    }
}

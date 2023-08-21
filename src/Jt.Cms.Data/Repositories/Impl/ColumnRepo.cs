using Jt.Common.Tool.DI;

namespace Jt.Cms.Data
{
    public class ColumnRepo : BaseRepo<Column>, IColumnRepo, ITransientDIInterface
    {
        public ColumnRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }
    }
}

using Jt.Common.Tool.DI;
using MySqlConnector;
using System.Data.Common;

namespace Jt.Cms.Data
{
    public class RoleActionRepo : BaseRepo<RoleAction>, IRoleActionRepo, ITransientDIInterface
    {
        public RoleActionRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<RoleAction>> GetRoleActionsAsync(int roleId)
        {
            string sql = "SELECT ra.*,ma.menu_id AS MenuId FROM role_action AS ra" +
                " LEFT JOIN menu_action AS ma" +
                " ON ra.action_id = ma.id" +
                " WHERE ra.role_id = @role_id";
            return await GetListAsync(sql, new DbParameter[]
            {
                new MySqlParameter(){ ParameterName = "role_id" ,Value = roleId }
            });
        }
    }
}

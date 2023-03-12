using Jt.SingleService.Core.DbContexts;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
using MySqlConnector;
using System.Data.Common;

namespace Jt.SingleService.Data.Repositories
{
    public class RoleActionRepo : BaseRepo<RoleAction>, IRoleActionRepo
    {
        public RoleActionRepo (MysqlDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<RoleAction>> GetRoleActionsAsync(int roleId)
        {
            string sql = "SELECT ra.*,ma.menu_id AS MenuId FROM role_action AS ra" +
                " LEFT JOIN menu_action AS ma" +
                " ON ra.action_id = ma.id" +
                " WHERE ra.role_id = @role_id";
            return await base.GetListAsync(sql, new DbParameter[] 
            {
                new MySqlParameter(){ ParameterName = "role_id" ,Value = roleId }
            });
        }
    }
}

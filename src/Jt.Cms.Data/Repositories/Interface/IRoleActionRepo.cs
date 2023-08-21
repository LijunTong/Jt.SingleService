namespace Jt.Cms.Data
{
    public interface IRoleActionRepo : IBaseRepo<RoleAction>
    {
        Task<List<RoleAction>> GetRoleActionsAsync(int roleId);
    }
}
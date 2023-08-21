namespace Jt.SingleService.Data
{
    public interface IRoleActionRepo : IBaseRepo<RoleAction>
    {
        Task<List<RoleAction>> GetRoleActionsAsync(int roleId);
    }
}
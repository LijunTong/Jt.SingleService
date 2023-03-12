using Jt.SingleService.Core.Tables;

namespace Jt.SingleService.Service.MenuSvc
{
    public interface IMenuSvc : IBaseSvc<Menu>
    {
        Task<bool> IsExistsMenuAsync(Menu menu);

        Task InsertMenuAsync(Menu menu);

        Task UpdateMenuAsync(Menu menu);

        Task<List<Menu>> GetMenuTreeWithActionAsync();

        Task InitControllerAsync(Type type);

        Task<List<string>> GetControllerAsync();

        /// <summary>
        /// 获取前台菜单
        /// </summary>
        /// <returns></returns>
        Task<List<Menu>> GetFrontMenuAsync();

        /// <summary>
        /// 获取后台菜单
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        Task<List<Menu>> GetBackMenuAsync(int userId);

        /// <summary>
        /// 根据路径获取菜单，一般路径都是唯一的
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<Menu> GetMenuAsync(string path);

        /// <summary>
        /// 绑定菜单和控制器，以便后续权限控制
        /// </summary>
        /// <param name="menu"></param>
        Task BindMenuAndControllerAsync(Menu menu);
    }
}
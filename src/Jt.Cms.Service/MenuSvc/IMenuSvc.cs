using Jt.Cms.Core;
using Jt.Cms.Data;
namespace Jt.Cms.Service
{
    public interface IMenuSvc : IBaseSvc<Menu>
    {
        Task<ApiResponse<bool>> IsExistsMenuAsync(Menu menu);

        Task InsertMenuAsync(Menu menu);

        Task UpdateMenuAsync(Menu menu);

        Task<ApiResponse<List<Menu>>> GetMenuTreeWithActionAsync();

        Task InitControllerAsync(Type type);

        Task<ApiResponse<List<string>>> GetControllerAsync();

        /// <summary>
        /// 获取前台菜单
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse<List<Menu>>> GetFrontMenuAsync();

        /// <summary>
        /// 获取后台菜单
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <returns></returns>
        Task<ApiResponse<List<Menu>>> GetBackMenuAsync(string userId);

        /// <summary>
        /// 根据路径获取菜单，一般路径都是唯一的
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<ApiResponse<Menu>> GetMenuAsync(string path);

        /// <summary>
        /// 绑定菜单和控制器，以便后续权限控制
        /// </summary>
        /// <param name="menu"></param>
        Task BindMenuAndControllerAsync(Menu menu);
    }
}
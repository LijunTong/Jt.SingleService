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
        /// ��ȡǰ̨�˵�
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse<List<Menu>>> GetFrontMenuAsync();

        /// <summary>
        /// ��ȡ��̨�˵�
        /// </summary>
        /// <param name="userId">�û�id</param>
        /// <returns></returns>
        Task<ApiResponse<List<Menu>>> GetBackMenuAsync(string userId);

        /// <summary>
        /// ����·����ȡ�˵���һ��·������Ψһ��
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<ApiResponse<Menu>> GetMenuAsync(string path);

        /// <summary>
        /// �󶨲˵��Ϳ��������Ա����Ȩ�޿���
        /// </summary>
        /// <param name="menu"></param>
        Task BindMenuAndControllerAsync(Menu menu);
    }
}
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
        /// ��ȡǰ̨�˵�
        /// </summary>
        /// <returns></returns>
        Task<List<Menu>> GetFrontMenuAsync();

        /// <summary>
        /// ��ȡ��̨�˵�
        /// </summary>
        /// <param name="userId">�û�id</param>
        /// <returns></returns>
        Task<List<Menu>> GetBackMenuAsync(int userId);

        /// <summary>
        /// ����·����ȡ�˵���һ��·������Ψһ��
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<Menu> GetMenuAsync(string path);

        /// <summary>
        /// �󶨲˵��Ϳ��������Ա����Ȩ�޿���
        /// </summary>
        /// <param name="menu"></param>
        Task BindMenuAndControllerAsync(Menu menu);
    }
}
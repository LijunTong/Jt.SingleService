using Jt.Cms.Core;
using Jt.Cms.Data;
namespace Jt.Cms.Service
{
    public interface IArticleSvc : IBaseSvc<Article>
    {
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="req">req</param>
        /// <returns>ApiResponse<bool></returns>
        Task<ApiResponse<bool>> AddArticleAsync(AddArticleReq req);

        /// <summary>
        /// �����ݸ�
        /// </summary>
        /// <param name="req">req</param>
        /// <returns>ApiResponse<bool></returns>
        Task<ApiResponse<bool>> PublishArticleAsync(PublishArticleReq req);

        /// <summary>
        /// �༭����
        /// </summary>
        /// <param name="req">req</param>
        /// <returns>ApiResponse<bool></returns>
        Task<ApiResponse<bool>> UpdateArticleAsync(AddArticleReq req);

        Task<ApiResponse<bool>> DelArticleAsync(AddArticleReq req);

        /// <summary>
        /// ������Ŀ��ȡ����
        /// </summary>
        /// <param name="req">req</param>
        /// <returns></returns>
        Task<ApiResponse<PagerOutput<Article>>> GetArticleByColumnAsync(GetArticleByColumnReq req);

        #region �ղ�

        /// <summary>
        /// ��������ղ�
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ApiResponse<bool>> AddArticleCollectAsync(AddArticleCollectReq req);

        /// <summary>
        /// ȡ�������ղ�
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ApiResponse<bool>> DelArticleCollectAsync(AddArticleCollectReq req);

        #endregion

        #region ����

        /// <summary>
        /// ������µ���
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ApiResponse<bool>> AddArticleLikeAsync(AddArticleCollectReq req);

        /// <summary>
        /// ȡ�����µ���
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ApiResponse<bool>> DelArticleLikeAsync(AddArticleCollectReq req);

        #endregion

        #region �Ķ���¼

        /// <summary>
        /// ��������Ķ���¼
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ApiResponse<bool>> AddArticleReadAsync(AddArticleCollectReq req);

        #endregion

        #region ����

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="req">req</param>
        /// <returns>ApiResponse<object></returns>
        Task<ApiResponse<bool>> AddArticleCommentAsync(AddArticleCommentReq req);

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ApiResponse<bool>> DelArticleCommentAsync(AddArticleCommentReq req);

        #endregion
    }
}
using Jt.Cms.Core;
using Jt.Cms.Data;
namespace Jt.Cms.Service
{
    public interface IArticleSvc : IBaseSvc<Article>
    {
        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="req">req</param>
        /// <returns>ApiResponse<bool></returns>
        Task<ApiResponse<bool>> AddArticleAsync(AddArticleReq req);

        /// <summary>
        /// 发布草稿
        /// </summary>
        /// <param name="req">req</param>
        /// <returns>ApiResponse<bool></returns>
        Task<ApiResponse<bool>> PublishArticleAsync(PublishArticleReq req);

        /// <summary>
        /// 编辑文章
        /// </summary>
        /// <param name="req">req</param>
        /// <returns>ApiResponse<bool></returns>
        Task<ApiResponse<bool>> UpdateArticleAsync(AddArticleReq req);

        Task<ApiResponse<bool>> DelArticleAsync(AddArticleReq req);

        /// <summary>
        /// 根据栏目获取文章
        /// </summary>
        /// <param name="req">req</param>
        /// <returns></returns>
        Task<ApiResponse<PagerOutput<Article>>> GetArticleByColumnAsync(GetArticleByColumnReq req);

        #region 收藏

        /// <summary>
        /// 添加文章收藏
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ApiResponse<bool>> AddArticleCollectAsync(AddArticleCollectReq req);

        /// <summary>
        /// 取消文章收藏
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ApiResponse<bool>> DelArticleCollectAsync(AddArticleCollectReq req);

        #endregion

        #region 点赞

        /// <summary>
        /// 添加文章点赞
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ApiResponse<bool>> AddArticleLikeAsync(AddArticleCollectReq req);

        /// <summary>
        /// 取消文章点赞
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ApiResponse<bool>> DelArticleLikeAsync(AddArticleCollectReq req);

        #endregion

        #region 阅读记录

        /// <summary>
        /// 添加文章阅读记录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ApiResponse<bool>> AddArticleReadAsync(AddArticleCollectReq req);

        #endregion

        #region 评论

        /// <summary>
        /// 添加文章评论
        /// </summary>
        /// <param name="req">req</param>
        /// <returns>ApiResponse<object></returns>
        Task<ApiResponse<bool>> AddArticleCommentAsync(AddArticleCommentReq req);

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<ApiResponse<bool>> DelArticleCommentAsync(AddArticleCommentReq req);

        #endregion
    }
}
namespace Jt.Cms.Data
{
    public interface IArticleRepo : IBaseRepo<Article>
    {
        /// <summary>
        /// 根据栏目获取文章
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<List<Article>> GetArticleByColumnAsync(GetArticleByColumnReq req);
    }
}
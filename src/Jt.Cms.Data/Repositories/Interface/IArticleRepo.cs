namespace Jt.Cms.Data
{
    public interface IArticleRepo : IBaseRepo<Article>
    {
        /// <summary>
        /// ������Ŀ��ȡ����
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        Task<List<Article>> GetArticleByColumnAsync(GetArticleByColumnReq req);
    }
}
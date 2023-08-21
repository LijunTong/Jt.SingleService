using Jt.Common.Tool.DI;
using Jt.Cms.Lib.Extensions;
using Jt.Common.Tool.Extension;
using Microsoft.EntityFrameworkCore;

namespace Jt.Cms.Data
{
    public class ArticleRepo : BaseRepo<Article>, IArticleRepo, ITransientDIInterface
    {
        public ArticleRepo(MysqlDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Article>> GetArticleByColumnAsync(GetArticleByColumnReq req)
        {
            var query = await IQueryableAsync();
            query = query.Include(x => x.ArticleColumns);
            if (req.Column.IsNotNullOrWhiteSpace())
            {
                query = query.Where(x => x.ArticleColumns.Any(x => x.ColumnId == req.Column));
            }

            var pager = await query.PagerAsync(req.Page, req.Size);
            req.Total = pager.Total;
            return pager.List;
        }
    }
}

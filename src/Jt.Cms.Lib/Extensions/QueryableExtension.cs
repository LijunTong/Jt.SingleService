using Microsoft.EntityFrameworkCore;

namespace Jt.Cms.Lib.Extensions
{
    public static class QueryableExtension
    {
        public static async Task<(int Total, List<T> List)> PagerAsync<T>(this IQueryable<T> queryable, int pageIndex, int pageSize)
        {
            int total = await queryable.CountAsync();
            queryable = queryable.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return (total, queryable.ToList());
        }
    }
}

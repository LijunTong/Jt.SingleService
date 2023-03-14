using Jt.SingleService.Core.Models;
using Jt.SingleService.Data.Tables;
using System.Linq.Expressions;

namespace Jt.SingleService.Service
{
    public interface IBaseSvc<T> where T : BaseEntity, new()
    {
        Task<T> InsertAsync(T entity);

        Task InsertListAsync(List<T> entity);

        Task<int> UpdateAsync(T entity);

        Task<int> DeleteAsync(dynamic id);

        Task<T> GetEntityByIdAsync(object id);

        Task<List<T>> GetPagerListAsync(Expression<Func<T, bool>> wherePredicate = null, PagerReq pager = null, Expression<Func<T, object>> orderKeySelector = null, bool isOrderBy = true);

        Task<List<T>> GetAllListAsync();

        Task<T> GetEntityAsync(Expression<Func<T, bool>> predicate);
    }
}

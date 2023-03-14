using Jt.SingleService.Core.Models;
using Jt.SingleService.Data.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using System.Linq.Expressions;

namespace Jt.SingleService.Data.Repositories.Interface
{
    public interface IBaseRepo<T> where T : BaseEntity, new()
    {
        DbSet<T> DbSet { get; }

        DbContext DbContext { get; }

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task<IDbContextTransaction> UseTransactionAsync(DbTransaction dbTransaction);

        Task<int> SaveAsync();

        Task<T> InsertAsync(T entity);

        Task InsertListAsync(List<T> entity);

        Task UpdateAsync(T entity);

        Task UpdateListAsync(List<T> entities);

        Task DeleteAsync(object id);

        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetByIdAsync(object id);

        Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate);

        Task<List<T>> GetListAsync(string sql);

        Task<List<T>> GetListAsync(string sql, DbParameter[] dbParameter);

        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate = null, PagerReq pager = null, Expression<Func<T, object>> orderBySelector = null, bool isOrderBy = true);

        Task<IQueryable<T>> IQueryableAsync(Expression<Func<T, bool>> predicate, PagerReq pager);

        Task<IQueryable<T>> IQueryableAsync();

        Task<IQueryable<T>> IQueryableAsync(Expression<Func<T, bool>> predicate);
    }
}

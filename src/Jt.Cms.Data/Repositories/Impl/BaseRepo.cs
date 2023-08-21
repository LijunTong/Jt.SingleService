using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using System.Linq.Expressions;

namespace Jt.Cms.Data
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity, new()
    {
        private readonly DbContext _dbContext;

        private DbSet<T> _dbSet;

        public BaseRepo(MysqlDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public DbSet<T> DbSet { get => _dbSet; }

        public DbContext DbContext { get => _dbContext; }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await DbContext.Database.BeginTransactionAsync();
        }

        public async Task<IDbContextTransaction> UseTransactionAsync(DbTransaction dbTransaction)
        {
            return await DbContext.Database.UseTransactionAsync(dbTransaction);
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await DbSet.FindAsync(id);
            entity.UpTime = DateTime.Now;
            entity.IsDel = 1;
            DbSet.Update(entity);
        }

        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await DbSet.Where(predicate).ToListAsync();
            entity.ForEach(x => x.IsDel = 1);
            DbSet.UpdateRange(entity);
        }

        public async Task RemoveAsync(string id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity);
        }

        public async Task RemoveAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await DbSet.Where(predicate).ToListAsync();
            DbSet.RemoveRange(entity);
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetListAsync(string sql)
        {
            return await DbSet.FromSqlRaw(sql).ToListAsync();
        }

        public async Task<List<T>> GetListAsync(string sql, DbParameter[] dbParameter)
        {
            return await DbSet.FromSqlRaw(sql, dbParameter).ToListAsync();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate = null, PagerReq pager = null, Expression<Func<T, object>> orderBySelector = null, bool isOrderBy = true)
        {
            IQueryable<T> result = DbSet;

            if (predicate != null)
            {
                result = result.Where(predicate);
            }
            if (orderBySelector != null)
            {
                if (isOrderBy)
                {
                    result = result.OrderBy(orderBySelector);
                }
                else
                {
                    result = result.OrderByDescending(orderBySelector);
                }
            }
            if (pager != null)
            {
                pager.Total = await result.CountAsync();
                result = result.Skip((pager.Page - 1) * pager.Size).Take(pager.Size);
            }

            return await result.ToListAsync();
        }

        public async Task<T> InsertAsync(T entity)
        {
            var result = await DbSet.AddAsync(entity);
            return result.Entity;
        }

        public async Task InsertListAsync(List<T> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }

        public async Task<IQueryable<T>> IQueryableAsync(Expression<Func<T, bool>> predicate, PagerReq pager)
        {
            IQueryable<T> result = DbSet;

            if (predicate != null)
            {
                result = result.Where(predicate);
            }
            if (pager != null)
            {
                pager.Total = await result.CountAsync();
                result = result.Skip((pager.Page - 1) * pager.Size).Take(pager.Size);
            }
            return result;
        }

        public async Task<IQueryable<T>> IQueryableAsync()
        {
            await Task.CompletedTask;
            return DbSet;
        }

        public async Task<IQueryable<T>> IQueryableAsync(Expression<Func<T, bool>> predicate)
        {
            await Task.CompletedTask;
            return DbSet.Where(predicate);
        }

        public async Task<int> SaveAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            await Task.CompletedTask;
        }

        public async Task UpdateListAsync(List<T> entities)
        {
            DbSet.UpdateRange(entities);
            await Task.CompletedTask;
        }

        public async Task UpdateFieldsAsync(T entity, Expression<Func<T, object>>[] propertyExpressions)
        {
            DbSet.Attach(entity);
            if (propertyExpressions.Any())
            {
                foreach (var item in propertyExpressions)
                {
                    DbContext.Entry(entity).Property(item).IsModified = true;
                }
            }
            await Task.CompletedTask;
        }

        protected Expression<Func<T, bool>> DefaultWhere => x => true;
    }
}

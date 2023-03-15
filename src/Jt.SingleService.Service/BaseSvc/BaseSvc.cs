using Jt.SingleService.Lib.DI;
using Jt.SingleService.Core.Models;
using Jt.SingleService.Data.Repositories.Interface;
using Jt.SingleService.Data.Tables;
using System.Linq.Expressions;

namespace Jt.SingleService.Service
{
    public class BaseSvc<T> : IBaseSvc<T> where T : BaseEntity, new ()
    {
        private readonly IBaseRepo<T> _baseRepo;

        public BaseSvc(IBaseRepo<T> baseRepo)
        {
            _baseRepo = baseRepo;
        }

        public async Task<bool> DeleteAsync(dynamic id)
        {
            await _baseRepo.DeleteAsync(id);
            return (await _baseRepo.SaveAsync()) >= 0;
        }

        public async Task<List<T>> GetAllListAsync()
        {
            var queryable = await _baseRepo.IQueryableAsync();
            return queryable.ToList();
        }

        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> predicate)
        {
            return await _baseRepo.GetFirstAsync(predicate);
        }

        public async Task<T> GetEntityByIdAsync(object id)
        {
            return await _baseRepo.GetByIdAsync(id);
        }

        public async Task<List<T>> GetPagerListAsync(Expression<Func<T, bool>> wherePredicate = null, PagerReq pager = null, Expression<Func<T, object>> orderKeySelector = null, bool isOrderBy = true)
        {
            return await _baseRepo.GetListAsync(wherePredicate, pager, orderKeySelector, isOrderBy);
        }

        public async Task<T> InsertAsync(T entity)
        {
            var t = await _baseRepo.InsertAsync(entity);
            await _baseRepo.SaveAsync();
            return t;
        }

        public async Task<bool> InsertListAsync(List<T> entities)
        {
            await _baseRepo.InsertListAsync(entities);
            return (await _baseRepo.SaveAsync()) > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            await _baseRepo.UpdateAsync(entity);
            return (await _baseRepo.SaveAsync()) > 0;
        }

        public async Task<bool> UpdateFieldsAsync(T entity, Expression<Func<T, object>>[] propertyExpressions)
        {
            await _baseRepo.UpdateFieldsAsync(entity, propertyExpressions);
            return (await _baseRepo.SaveAsync()) > 0;
        }
    }
}

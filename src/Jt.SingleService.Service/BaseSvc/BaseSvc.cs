using Jt.SingleService.Core.DI;
using Jt.SingleService.Core.Models;
using Jt.SingleService.Core.Repositories;
using Jt.SingleService.Core.Tables;
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

        public async Task<int> DeleteAsync(dynamic id)
        {
            await _baseRepo.DeleteAsync(id);
            return await _baseRepo.SaveAsync();
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

        public async Task InsertListAsync(List<T> entities)
        {
            await _baseRepo.InsertListAsync(entities);
            await _baseRepo.SaveAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            await _baseRepo.UpdateAsync(entity);
            return await _baseRepo.SaveAsync();
        }
    }
}

using Jt.SingleService.Core;
using Jt.SingleService.Data;
using Jt.Common.Tool.Extension;
using System.Linq.Expressions;

namespace Jt.SingleService.Service
{
    public class BaseSvc<T> : IBaseSvc<T> where T : BaseEntity, new()
    {
        private readonly IBaseRepo<T> _baseRepo;
        protected static readonly IIDSvc _IDSvc;

        static BaseSvc()
        {
            _IDSvc = new IDSvc();
        }

        public BaseSvc(IBaseRepo<T> baseRepo)
        {
            _baseRepo = baseRepo;
        }

        public async Task<ApiResponse<bool>> DeleteAsync(string id)
        {
            await _baseRepo.DeleteAsync(id);
            var data = (await _baseRepo.SaveAsync()) >= 0;
            return ApiResponse<bool>.Succeed(data);
        }

        public async Task<ApiResponse<List<T>>> GetAllListAsync()
        {
            var queryable = await _baseRepo.IQueryableAsync(x => x.IsDel == 0);
            var data = queryable.ToList();
            return ApiResponse<List<T>>.Succeed(data);
        }

        public async Task<ApiResponse<T>> GetEntityAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
            {
                predicate = x => x.IsDel == 0;
            }
            else
            {
                predicate = predicate.And(x => x.IsDel == 0);
            }

            var data = await _baseRepo.GetFirstAsync(predicate);
            return ApiResponse<T>.Succeed(data);
        }

        public async Task<ApiResponse<T>> GetEntityByIdAsync(string id)
        {
            var data = await _baseRepo.GetFirstAsync(x => x.Id == id && x.IsDel == 0);
            return ApiResponse<T>.Succeed(data);
        }

        public async Task<ApiResponse<PagerOutput<T>>> GetPagerListAsync(Expression<Func<T, bool>> wherePredicate = null, PagerReq pager = null, Expression<Func<T, object>> orderKeySelector = null, bool isOrderBy = true)
        {
            if (wherePredicate == null)
            {
                wherePredicate = x => x.IsDel == 0;
            }
            else
            {
                wherePredicate = wherePredicate.And(x => x.IsDel == 0);
            }

            var result = await _baseRepo.GetListAsync(wherePredicate, pager, orderKeySelector, isOrderBy);

            var data = new PagerOutput<T>
            {
                Total = pager.Total,
                Data = result
            };

            return ApiResponse<PagerOutput<T>>.Succeed(data);
        }

        public async Task<ApiResponse<T>> InsertAsync(T entity)
        {
            entity.Id = _IDSvc.NextId();
            entity.CreateTime = DateTime.Now;
            entity.UpTime = DateTime.Now;
            var t = await _baseRepo.InsertAsync(entity);
            await _baseRepo.SaveAsync();
            return ApiResponse<T>.Succeed(t);
        }

        public async Task<ApiResponse<bool>> InsertListAsync(List<T> entities)
        {
            await _baseRepo.InsertListAsync(entities);
            var data = (await _baseRepo.SaveAsync()) > 0;
            return ApiResponse<bool>.Succeed(data);
        }

        public async Task<ApiResponse<bool>> UpdateAsync(T entity)
        {
            entity.UpTime = DateTime.Now;
            await _baseRepo.UpdateAsync(entity);
            var data = (await _baseRepo.SaveAsync()) > 0;
            return ApiResponse<bool>.Succeed(data);
        }

        public async Task<ApiResponse<bool>> UpdateFieldsAsync(T entity, Expression<Func<T, object>>[] propertyExpressions)
        {
            await _baseRepo.UpdateFieldsAsync(entity, propertyExpressions);
            var data = (await _baseRepo.SaveAsync()) > 0;
            return ApiResponse<bool>.Succeed(data);
         }

        protected ApiResponse<bool> ReturnFlag(int flag, string msg = "")
        {
            return ReturnFlag(flag == 1, msg);
        }

        protected ApiResponse<bool> ReturnFlag(bool flag, string msg = "")
        {
            if (flag)
            {
                return ApiResponse<bool>.Succeed(true);
            }

            return ApiResponse<bool>.OperationFail(msg);
        }
    }
}

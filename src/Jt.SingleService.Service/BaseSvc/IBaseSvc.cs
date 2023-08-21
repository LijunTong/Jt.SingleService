using Jt.SingleService.Core;
using Jt.SingleService.Data;
using System.Linq.Expressions;

namespace Jt.SingleService.Service
{
    public interface IBaseSvc<T> where T : BaseEntity, new()
    {
        Task<ApiResponse<T>> InsertAsync(T entity);

        Task<ApiResponse<bool>> InsertListAsync(List<T> entity);

        Task<ApiResponse<bool>> UpdateAsync(T entity);

        Task<ApiResponse<bool>> DeleteAsync(string id);

        /// <summary>
        /// 根据id查询并且IsDel = 0的数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResponse<T>> GetEntityByIdAsync(string id);

        /// <summary>
        /// 分页查询IsDel = 0的数据
        /// </summary>
        /// <param name="wherePredicate"></param>
        /// <param name="pager"></param>
        /// <param name="orderKeySelector"></param>
        /// <param name="isOrderBy"></param>
        /// <returns></returns>
        Task<ApiResponse<PagerOutput<T>>> GetPagerListAsync(Expression<Func<T, bool>> wherePredicate = null, PagerReq pager = null, Expression<Func<T, object>> orderKeySelector = null, bool isOrderBy = true);

        /// <summary>
        /// 获取所有IsDel=0的数据
        /// </summary>
        /// <returns></returns>
        Task<ApiResponse<List<T>>> GetAllListAsync();

        /// <summary>
        /// 根据条件查询，并且是IsDel=0的
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<ApiResponse<T>> GetEntityAsync(Expression<Func<T, bool>> predicate);

        Task<ApiResponse<bool>> UpdateFieldsAsync(T entity, Expression<Func<T, object>>[] propertyExpressions);
    }
}

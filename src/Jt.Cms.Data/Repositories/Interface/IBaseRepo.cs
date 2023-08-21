using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data.Common;
using System.Linq.Expressions;

namespace Jt.Cms.Data
{
    public interface IBaseRepo<T> where T : BaseEntity, new()
    {
        /// <summary>
        /// 数据集合
        /// </summary>
        DbSet<T> DbSet { get; }

        /// <summary>
        /// 上下文
        /// </summary>
        DbContext DbContext { get; }

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns></returns>
        Task<IDbContextTransaction> BeginTransactionAsync();

        /// <summary>
        /// 跨数据库链接事务
        /// </summary>
        /// <param name="dbTransaction">事务</param>
        /// <returns></returns>
        Task<IDbContextTransaction> UseTransactionAsync(DbTransaction dbTransaction);

        /// <summary>
        /// 保存，每次更新数据库都需要手动提交保存
        /// </summary>
        /// <returns></returns>
        Task<int> SaveAsync();

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task<T> InsertAsync(T entity);

        /// <summary>
        /// 批量新增实体
        /// </summary>
        /// <param name="entities">实体列表</param>
        /// <returns></returns>
        Task InsertListAsync(List<T> entities);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        Task UpdateAsync(T entity);

        /// <summary>
        /// 批量修改实体
        /// </summary>
        /// <param name="entities">实体列表</param>
        /// <returns></returns>
        Task UpdateListAsync(List<T> entities);

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        Task DeleteAsync(string id);

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="predicate">predicate</param>
        /// <returns></returns>
        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        Task RemoveAsync(string id);

        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="predicate">predicate</param>
        /// <returns></returns>
        Task RemoveAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 通过id获取
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        Task<T> GetByIdAsync(string id);

        /// <summary>
        /// 通过条件获取
        /// </summary>
        /// <param name="predicate">predicate</param>
        /// <returns></returns>
        Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// sql查询
        /// </summary>
        /// <param name="sql">sql</param>
        /// <returns></returns>
        Task<List<T>> GetListAsync(string sql);

        /// <summary>
        /// sql查询 有参数
        /// </summary>
        /// <param name="sql">sql</param>
        /// <param name="dbParameter">dbParameter</param>
        /// <returns></returns>
        Task<List<T>> GetListAsync(string sql, DbParameter[] dbParameter);

        /// <summary>
        /// 分页，排序
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <param name="pager">分页对象</param>
        /// <param name="orderBySelector">排序对象</param>
        /// <param name="isOrderBy">是否升序</param>
        /// <returns></returns>
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate = null, PagerReq pager = null, Expression<Func<T, object>> orderBySelector = null, bool isOrderBy = true);

        /// <summary>
        /// 获取Queryable
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="pager"></param>
        /// <returns></returns>
        Task<IQueryable<T>> IQueryableAsync(Expression<Func<T, bool>> predicate, PagerReq pager);

        /// <summary>
        /// 获取Queryable
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<T>> IQueryableAsync();

        /// <summary>
        /// 获取Queryable
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IQueryable<T>> IQueryableAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 更新具体的字段
        /// </summary>
        /// <param name="entity">entity</param>
        /// <param name="propertyExpressions">字段选择</param>
        /// <returns></returns>
        Task UpdateFieldsAsync(T entity, Expression<Func<T, object>>[] propertyExpressions);
    }
}

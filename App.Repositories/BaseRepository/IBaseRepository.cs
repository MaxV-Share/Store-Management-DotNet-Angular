using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MaxV.Common.Model;

namespace App.Repositories.BaseRepository
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<int> CreateAsync(List<TEntity> entities);

        Task<int> CreateAsync(TEntity entity);

        Task<int> UpdateAsync(TEntity entity);

        Task<int> UpdateAsync(IEnumerable<TEntity> entities);

        Task DeleteHardAsync(params object[] keyValues);

        void DeleteHard(TEntity entity);

        Task DeleteSoftAsync(params object[] keyValues);

        Task DeleteSoftAsync(TEntity entity);

        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetByIdNoTrackingAsync(TKey id, params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> GetQueryableTable(params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> GetNoTrackingEntities(params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> GetNoTrackingEntitiesIdentityResolution(params Expression<Func<TEntity, object>>[] includes);
    }
}
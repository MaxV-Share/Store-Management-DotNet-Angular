using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Repositories.BaseRepository
{
    public interface IBaseRepository<TEntity, TKey>
    {
        Task<IEnumerable<TEntity>> CreateAsync(List<TEntity> entities);
        Task<TEntity> CreateAsync(TEntity entity);
        Task DeleteHardAsync(params object[] keyValues);
        Task DeleteSoftAsync(params object[] keyValues);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        Task<TEntity> GetByIdNoTrackingAsync(TKey id);
        IQueryable<TEntity> GetQueryableTable();
        IQueryable<TEntity> GetNoTrackingEntities();
        IQueryable<TEntity> GetNoTrackingEntitiesIdentityResolution();
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entity);
    }
}

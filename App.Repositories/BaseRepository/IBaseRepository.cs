﻿using MaxV.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Repositories.BaseRepository
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> CreateAsync(List<TEntity> entities);
        Task<TEntity> CreateAsync(TEntity entity);
        Task DeleteHardAsync(params object[] keyValues);
        Task DeleteSoftAsync(params object[] keyValues);
        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdNoTrackingAsync(TKey id, params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> GetQueryableTable(params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> GetNoTrackingEntities(params Expression<Func<TEntity, object>>[] includes);
        IQueryable<TEntity> GetNoTrackingEntitiesIdentityResolution(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entity);
    }
}

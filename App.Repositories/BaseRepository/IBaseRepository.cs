﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App.Common.Model;

namespace App.Repositories.BaseRepository
{
    public interface IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<int> CreateAsync(List<TEntity> entities);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> CreateAsync(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(IEnumerable<TEntity> entities);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task DeleteHardAsync(params object[] keyValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void DeleteHard(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<int> DeleteSoftAsync(params object[] keyValues);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> DeleteSoftAsync(TEntity entity);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<List<TEntity>> GetAllAsync(params Expression<Func<TEntity, object>>[] includes);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdAsync(TKey id, params Expression<Func<TEntity, object>>[] includes);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        Task<TEntity> GetByIdNoTrackingAsync(TKey id, params Expression<Func<TEntity, object>>[] includes);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetQueryableTable(params Expression<Func<TEntity, object>>[] includes);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetNoTrackingEntities(params Expression<Func<TEntity, object>>[] includes);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetNoTrackingEntitiesIdentityResolution(params Expression<Func<TEntity, object>>[] includes);
    }
}
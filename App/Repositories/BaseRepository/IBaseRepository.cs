using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Repositories.BaseRepository
{
    public interface IBaseRepository<T, TKey>
    {
        Task<IEnumerable<T>> CreateAsync(List<T> entities);
        Task<T> CreateAsync(T entity);
        Task DeleteHardAsync(TKey id);
        Task DeleteSoftAsync(TKey id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(TKey id);
        Task<T> GetByIdNoTrackingAsync(TKey id);
        Task<T> GetByUuidAsync(Guid uuid);
        Task<T> GetByUuidNoTrackingAsync(Guid uuid);
        IQueryable<T> GetQueryableTable();
        IQueryable<T> GetNoTrackingEntities();
        IQueryable<T> GetNoTrackingEntitiesIdentityResolution();
        Task<T> UpdateAsync(T entity);
        Task<IEnumerable<T>> UpdateAsync(IEnumerable<T> entity);
    }
}

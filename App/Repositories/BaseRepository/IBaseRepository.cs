using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Repositories.BaseRepository
{
    public interface IBaseRepository<T> : IDisposable
    {
        public IQueryable<T> GetQueryableTable();
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByUuidAsync(Guid uuid);
        public Task<T> GetByIdAsync(int id);
        public Task<T> GetByIdNoTrackingAsync(int id);
        public Task<T> GetByUuidTrackingAsync(Guid uuid);
        public Task<T> CreateAsync(T entity);
        public Task<IEnumerable<T>> CreateAsync(List<T> entities);
        public Task<int> UpdateAsync(T entity);
        public Task<int> DeleteHardAsync(int id);
        public Task<int> DeleteSoftAsync(int id);
    }
}

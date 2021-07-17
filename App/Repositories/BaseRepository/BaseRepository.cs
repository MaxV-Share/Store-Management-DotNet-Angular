using App.Models;
using AutoMapper;
using MaxV.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Repositories.BaseRepository
{
    public class BaseRepository<T, TKey> : IBaseRepository<T, TKey> where T : BaseEntity<TKey> 
    {
        #region props

        private readonly DbContext _context;
        private bool _disposed = false;
        private IDbContextTransaction _tx { get; set; }
        private DbSet<T> _entitiesDbSet { get; set; }

        #endregion props

        #region ctor

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        ~BaseRepository()
        {
            Dispose(false);
        }

        #endregion ctor

        #region public

        public IQueryable<T> GetQueryableTable()
        {
            return Entities.AsQueryable<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await GetNoTrackingEntities().ToListAsync();
            return entities;
        }

        public virtual async Task<T> GetByIdAsync(TKey id)
        {
            var entity = await Entities.SingleOrDefaultAsync(x => id.Equals(x.Id));
            return entity;
        }

        public virtual async Task<T> GetByIdNoTrackingAsync(TKey id)
        {
            var entity = await GetNoTrackingEntities().SingleOrDefaultAsync(x => x.Id.Equals(id));
            return entity;
        }
        public virtual async Task<T> GetByUuidNoTrackingAsync(Guid uuid)
        {
            var entity = await GetNoTrackingEntities().SingleOrDefaultAsync(x => x.Uuid == uuid);
            return entity;
        }
        public async Task<T> CreateAsync(T entity)
        {
            ValidateAndThrow(entity);
            AddDefaultValue(ref entity);
            Entities.Add(entity);

            var effectedCount = await _context.SaveChangesAsync();
            if (effectedCount == 0)
            {
                return null;
            }
            return entity;
        }

        public async Task<IEnumerable<T>> CreateAsync(List<T> entities)
        {
            for (int i = 0; i < entities.Count; i++)
            {
                var entity = entities[i];
                ValidateAndThrow(entity);
                AddDefaultValue(ref entity);
            }

            Entities.AddRange(entities);
            var effectedCount = await _context.SaveChangesAsync();
            if (effectedCount == 0)
            {
                return null;
            }
            return entities;
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            ValidateAndThrow(entity);
            var entry = _context.Entry(entity);
            if (entry.State < EntityState.Added)
            {
                entry.State = EntityState.Modified;
            }

            entity.UpdateAt = DateTime.UtcNow;
            var effectedCount = await _context.SaveChangesAsync();
            return effectedCount;
        }

        public virtual async Task<int> DeleteHardAsync(TKey id)
        {
            var entity = await _context.Set<T>().SingleOrDefaultAsync(e => e.Id.Equals(id));
            ValidateAndThrow(entity);
            Entities.Remove(entity);
            var effectedCount = await _context.SaveChangesAsync();
            return effectedCount;
        }
        public virtual async Task<int> DeleteSoftAsync(TKey id)
        {
            var entity = await _context.Set<T>().SingleOrDefaultAsync(e => e.Id.Equals(id));
            ValidateAndThrow(entity);
            entity.Deleted = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            var effectedCount = await UpdateAsync(entity);
            return effectedCount;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual async Task<T> GetByUuidAsync(Guid uuid)
        {
            var entity = await Entities.SingleOrDefaultAsync(x => x.Uuid == uuid);
            return entity;
        }
        #endregion public

        #region private

        private void ValidateAndThrow(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        private void AddDefaultValue(ref T entity)
        {
            BaseEntity<TKey>.SetDefaultValue(ref entity);
        }

        protected DbSet<T> Entities
        {
            get
            {
                if (_entitiesDbSet == null)
                    _entitiesDbSet = _context.Set<T>();
                return _entitiesDbSet;
            }
        }

        public IQueryable<T> GetNoTrackingEntities()
        {
            return Entities.AsNoTracking();
        }
        public IQueryable<T> GetNoTrackingEntitiesIdentityResolution()
        {
            return Entities.AsNoTrackingWithIdentityResolution();
        }

        public async Task BeginTransactionAsync()
        {
            _tx = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _tx.CommitAsync();
            await ReleaseTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _tx.RollbackAsync();
            await ReleaseTransactionAsync();
        }

        public async Task ReleaseTransactionAsync()
        {
            await _tx.DisposeAsync();
            _tx = null;
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _tx?.Dispose();
                _tx = null;
            }

            _disposed = true;
        }

        #endregion private

    }
}

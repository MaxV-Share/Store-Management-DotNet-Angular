using App.Infrastructures.UnitOffWorks;
using App.Models;
using App.Services.Interface;
using AutoMapper;
using MaxV.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Repositories.BaseRepository
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        #region props

        protected readonly DbContext _context;
        private DbSet<TEntity> _entitiesDbSet { get; set; }
        public readonly IUserService _userService;
        private readonly ILogger _logger;
        #endregion props

        #region ctor

        public BaseRepository(DbContext context, IUserService userService, ILogger logger)
        {
            _context = context;
            _userService = userService;
            _logger = logger;
        }

        ~BaseRepository()
        {

        }

        #endregion ctor

        #region public

        public IQueryable<TEntity> GetQueryableTable()
        {
            return Entities.AsQueryable<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entities = await GetNoTrackingEntities().ToListAsync();
            return entities;
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            var entity = await Entities.SingleOrDefaultAsync(x => id.Equals(x.Id));
            return entity;
        }

        public virtual async Task<TEntity> GetByIdNoTrackingAsync(TKey id)
        {
            var entity = await GetNoTrackingEntities().SingleOrDefaultAsync(x => x.Id.Equals(id));
            return entity;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            ValidateAndThrow(entity);
            var currentUser = await _userService.GetCurrentUser();
            entity.SetDefaultValue(currentUser?.UserName);
            Entities.Add(entity);
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> CreateAsync(List<TEntity> entities)
        {
            ValidateAndThrow(entities);
            var currentUser = await _userService.GetCurrentUser();
            entities.ForEach(e =>
            {
                e.SetDefaultValue(currentUser?.UserName);
            });

            Entities.AddRange(entities);
            return entities;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            ValidateAndThrow(entity);
            var currentUser = await _userService.GetCurrentUser();
            entity.SetValueUpdate(currentUser?.UserName);
            var entry = _context.Entry(entity);
            if (entry.State < EntityState.Added)
            {
                entry.State = EntityState.Modified;
            }
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities)
        {
            var currentUser = await _userService.GetCurrentUser();
            entities.ToList().ForEach(e =>
            {
                ValidateAndThrow(e);
                e.SetValueUpdate(currentUser?.UserName);
            });

            var entry = _context.Entry(entities);
            if (entry.State < EntityState.Added)
            {
                entry.State = EntityState.Modified;
            }
            return entities;
        }

        public virtual async Task DeleteHardAsync(params object[] keyValues)
        {
            var entity = await _context.Set<TEntity>().FindAsync(keyValues);
            ValidateAndThrow(entity);
            Entities.Remove(entity);
        }
        public virtual async Task DeleteSoftAsync(params object[] keyValues)
        {
            var entity = await _context.Set<TEntity>().FindAsync(keyValues);
            ValidateAndThrow(entity);
            entity.Deleted = DateTime.Now.ToString("yyyyMMddHHmmss");
            await UpdateAsync(entity);
        }
        #endregion public

        #region private

        protected void ValidateAndThrow(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        protected void ValidateAndThrow(IEnumerable<TEntity> entities)
        {
            if (entities == null || entities.Count() == 0)
            {
                throw new ArgumentNullException(nameof(entities));
            }
        }

        protected DbSet<TEntity> Entities
        {
            get
            {
                if (_entitiesDbSet == null)
                    _entitiesDbSet = _context.Set<TEntity>();
                return _entitiesDbSet;
            }
        }

        public IQueryable<TEntity> GetNoTrackingEntities()
        {
            return Entities.AsNoTracking();
        }
        public IQueryable<TEntity> GetNoTrackingEntitiesIdentityResolution()
        {
            return Entities.AsNoTrackingWithIdentityResolution();
        }

        #endregion private

    }
}

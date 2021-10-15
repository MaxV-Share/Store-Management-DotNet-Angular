﻿using App.Repositories.UnitOffWorks;
using App.Models;
using AutoMapper;
using MaxV.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace App.Repositories.BaseRepository
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        #region props

        protected readonly DbContext _context;
        private DbSet<TEntity> _entitiesDbSet { get; set; }
        public readonly IHttpContextAccessor _httpContextAccessor;
        #endregion props

        #region ctor

        public BaseRepository(DbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        ~BaseRepository()
        {

        }

        #endregion ctor

        #region public

        public IQueryable<TEntity> GetQueryableTable()
        {
            return Entities.AsQueryable();
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            var entities = GetNoTrackingEntities().ToListAsync();
            return entities;
        }

        public virtual Task<TEntity> GetByIdAsync(TKey id)
        {
            var entity = Entities.SingleOrDefaultAsync(x => id.Equals(x.Id));
            return entity;
        }

        public virtual Task<TEntity> GetByIdNoTrackingAsync(TKey id)
        {
            var entity = GetNoTrackingEntities().SingleOrDefaultAsync(x => x.Id.Equals(id));
            return entity;
        }

        public virtual Task<TEntity> CreateAsync(TEntity entity)
        {
            ValidateAndThrow(entity);
            var currentUserName = GetUserNameInHttpContext();
            entity.SetDefaultValue(currentUserName);
            Entities.Add(entity);
            return Task.FromResult(entity);
        }

        public virtual Task<IEnumerable<TEntity>> CreateAsync(List<TEntity> entities)
        {
            ValidateAndThrow(entities);
            var currentUserName = GetUserNameInHttpContext();
            entities.ForEach(e =>
            {
                e.SetDefaultValue(currentUserName);
            });

            Entities.AddRange(entities);
            return Task.FromResult(entities.AsEnumerable());
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            ValidateAndThrow(entity);
            var currentUserName = GetUserNameInHttpContext();
            var entry = _context.Entry(entity);
            entity.SetValueUpdate(currentUserName);
            if (entry.State < EntityState.Added)
            {
                entry.State = EntityState.Modified;
            }
            return Task.FromResult(entity);
        }

        public virtual Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities)
        {
            var currentUserName = GetUserNameInHttpContext();
            entities.ToList().ForEach(e =>
            {
                ValidateAndThrow(e);
                e.SetValueUpdate(currentUserName);
            });

            var entry = _context.Entry(entities);
            if (entry.State < EntityState.Added)
            {
                entry.State = EntityState.Modified;
            }
            return Task.FromResult(entities);
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
            UpdateAsync(entity);
        }
        #endregion public

        #region private
        protected string GetUserNameInHttpContext()
        {

            var userName = _httpContextAccessor.HttpContext.User.FindFirst(claim => claim.Type == ClaimTypes.Name)?.Value;
            return userName;
        }
        protected void ValidateAndThrow(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
        }

        protected void ValidateAndThrow(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
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

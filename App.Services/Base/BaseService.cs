using App.Repositories.UnitOffWorks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using App.Models.DTOs.PagingViewModels;
using App.EFCore;
using MaxV.Common.Model.DTOs;
using MaxV.Common.Model;
using App.Common.Extensions;

namespace App.Services.Base
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TCreateRequest"></typeparam>
    /// <typeparam name="TUpdateRequest"></typeparam>
    /// <typeparam name="TViewModel"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    public abstract class BaseService<TEntity, TCreateRequest, TUpdateRequest, TViewModel, TKey> : IBaseService<TEntity, TCreateRequest, TUpdateRequest, TViewModel, TKey>
        where TEntity : BaseEntity<TKey>, new()
        where TCreateRequest : BaseCreateRequest, new()
        where TUpdateRequest : BaseUpdateRequest<TKey>, new()
        where TViewModel : BaseViewModel<TKey>, new()
    {
        protected readonly IMapper _mapper;
        protected readonly IUnitOffWork _unitOffWork;
        protected readonly ILogger _logger;
        protected BaseService(IMapper mapper, IUnitOffWork unitOffWork, ILogger logger)
        {
            _mapper = mapper;
            _unitOffWork = unitOffWork;
            _logger = logger;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteHardAsync(TKey id)
        {
            await _unitOffWork.Repository<TEntity, TKey>().DeleteHardAsync(id);
            return await _unitOffWork.SaveChangesAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteSoftAsync(TKey id)
        {
            await _unitOffWork.Repository<TEntity, TKey>().DeleteSoftAsync(id);
            return await _unitOffWork.SaveChangesAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TViewModel>> GetAllDTOAsync()
        {
            var repository = _unitOffWork.Repository<TEntity, TKey>();
            var entities = await repository.GetNoTrackingEntities().ToListAsync();
            var result = _mapper.Map<IEnumerable<TViewModel>>(entities);
            return result;
        }
        public virtual async Task<TViewModel> GetByIdAsync(TKey id)
        {
            var entity = await _unitOffWork.Repository<TEntity, TKey>().GetByIdAsync(id);
            var result = _mapper.Map<TViewModel>(entity);
            return result;
        }
        public virtual async Task<int> UpdateAsync(TKey id, TUpdateRequest request)
        {
            if (!id.Equals(request.Id))
                throw new KeyNotFoundException();
            var entity = await _unitOffWork.Repository<TEntity, TKey>().GetByIdAsync(id);

            if (entity == null)
            {
                throw new NullReferenceException();
            }
            entity = _mapper.Map(request, entity);
            await _unitOffWork.Repository<TEntity, TKey>().UpdateAsync(entity);
            var result = await _unitOffWork.SaveChangesAsync();
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public virtual async Task<TViewModel> CreateAsync(TCreateRequest request)
        {
            var entityNew = new TEntity();
            _mapper.Map(request, entityNew);
            await _unitOffWork.DoWorkWithTransaction(async () =>
            {
                await _unitOffWork.Repository<TEntity, TKey>().CreateAsync(entityNew);
                var effectedCount = await _unitOffWork.SaveChangesAsync();
                if (effectedCount <= 0)
                {
                    throw new NullReferenceException();
                }
            });
            var result = _mapper.Map<TViewModel>(entityNew);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public virtual async Task<IEnumerable<TViewModel>> CreateAsync(IEnumerable<TCreateRequest> request)
        {
            var entitiesNew = new List<TEntity>();
            _mapper.Map(request, entitiesNew);
            IEnumerable<TEntity> response = new List<TEntity>();
            await _unitOffWork.DoWorkWithTransaction(async () =>
            {
                var affectedCount = await _unitOffWork.Repository<TEntity, TKey>().CreateAsync(entitiesNew);
                if (affectedCount <= 0)
                {
                    throw new NullReferenceException();
                }
            });

            var result = _mapper.Map<IEnumerable<TViewModel>>(response);
            return result;
        }

    }
}

using MaxV.Base;
using App.Repositories.BaseRepository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Infrastructures.UnitOffWorks;
using MaxV.Base.DTOs;
using Microsoft.Extensions.Logging;

namespace App.Services.Base
{
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

        public async Task<int> DeleteHardAsync(TKey id)
        {
            await _unitOffWork.BaseRepository<TEntity, TKey>().DeleteHardAsync(id);
            return await _unitOffWork.SaveChangesAsync();
        }

        public async Task<int> DeleteSoftAsync(TKey id)
        {
            await _unitOffWork.BaseRepository<TEntity, TKey>().DeleteSoftAsync(id);
            return await _unitOffWork.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TViewModel>> GetAllDTOAsync()
        {
            var entities = await _unitOffWork.BaseRepository<TEntity, TKey>().GetAllAsync();
            var result = _mapper.Map<IEnumerable<TViewModel>>(entities);
            return result;
        }

        public virtual async Task<TViewModel> GetByIdAsync(TKey id)
        {
            var entity = await _unitOffWork.BaseRepository<TEntity, TKey>().GetByIdAsync(id);
            var result = _mapper.Map<TViewModel>(entity);
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual async Task<int> UpdateAsync(TKey id, TUpdateRequest request)
        {
            if (!id.Equals(request.Id))
                throw new KeyNotFoundException();
            var entity = await _unitOffWork.BaseRepository<TEntity, TKey>().GetByIdAsync(id);

            if (entity == null)
            {
                throw new NullReferenceException();
            }
            entity = _mapper.Map(request, entity);
            await _unitOffWork.BaseRepository<TEntity, TKey>().UpdateAsync(entity);
            var result = await _unitOffWork.SaveChangesAsync();
            return result;
        }
        public virtual async Task<TViewModel> CreateAsync(TCreateRequest request)
        {
            var entityNew = new TEntity();
            _mapper.Map(request, entityNew);
            await _unitOffWork.DoWorkWithTransaction(async () =>
            {
                await _unitOffWork.BaseRepository<TEntity, TKey>().CreateAsync(entityNew);
                var effectedCount = await _unitOffWork.SaveChangesAsync();
                if (effectedCount <= 0)
                {
                    throw new NullReferenceException();
                }
            });
            var result = _mapper.Map<TViewModel>(entityNew);
            return result;
        }
        public virtual async Task<IEnumerable<TViewModel>> CreateAsync(IEnumerable<TCreateRequest> request)
        {
            var entitiesNew = new List<TEntity>();
            _mapper.Map(request, entitiesNew);
            IEnumerable<TEntity> response = new List<TEntity>();
            await _unitOffWork.DoWorkWithTransaction(async () =>
            {
                response = await _unitOffWork.BaseRepository<TEntity, TKey>().CreateAsync(entitiesNew);
                var effectedCount = await _unitOffWork.SaveChangesAsync();
                if (effectedCount <= 0)
                {
                    throw new NullReferenceException();
                }
            });
            var result = _mapper.Map<IEnumerable<TViewModel>>(response);
            return result;
        }
    }
}

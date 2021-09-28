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
        public IBaseRepository<TEntity, TKey> _repository;
        public readonly IMapper _mapper;
        public readonly IUnitOffWork _unitOffWork;
        public readonly ILogger _logger;
        public BaseService(IBaseRepository<TEntity, TKey> repository, IMapper mapper, IUnitOffWork unitOffWork, ILogger logger)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOffWork = unitOffWork;
            _logger = logger;
        }

        public async Task<int> DeleteHardAsync(TKey id)
        {
            await _repository.DeleteHardAsync(id);
            return await _unitOffWork.SaveChangesAsync();
        }

        public async Task<int> DeleteSoftAsync(TKey id)
        {
            await _repository.DeleteSoftAsync(id);
            return await _unitOffWork.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TViewModel>> GetAllDTOAsync()
        {
            var entities = await _repository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<TViewModel>>(entities);
            return result;
        }

        public virtual async Task<TViewModel> GetByIdAsync(TKey id)
        {
            var entity = await _repository.GetByIdAsync(id);
            var result = _mapper.Map<TViewModel>(entity);
            return result;
        }

        public virtual async Task<int> UpdateAsync(TKey id, TUpdateRequest request)
        {
            if (!id.Equals(request.Id))
                throw new KeyNotFoundException();
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                throw new NullReferenceException();
            }
            entity = _mapper.Map(request, entity);

            try
            {
                await _repository.UpdateAsync(entity);
                var result = await _unitOffWork.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {
                await _unitOffWork.RollbackTransactionAsync();
                throw;
            }
        }
        public virtual async Task<TViewModel> CreateAsync(TCreateRequest request)
        {
            var entityNew = new TEntity();
            _mapper.Map(request, entityNew);
            try
            {
                var response = await _repository.CreateAsync(entityNew);
                var effectedCount = await _unitOffWork.SaveChangesAsync();
                if (effectedCount <= 0)
                {
                    throw new NullReferenceException();
                }
                var result = _mapper.Map<TViewModel>(response);
                return result;
            }
            catch (NullReferenceException)
            {
                await _unitOffWork.RollbackTransactionAsync();
                throw;
            }
            catch (Exception)
            {
                await _unitOffWork.RollbackTransactionAsync();
                throw;
            }
        }
        public virtual async Task<IEnumerable<TViewModel>> CreateAsync(IEnumerable<TCreateRequest> request)
        {
            var entitiesNew = new List<TEntity>();
            _mapper.Map(request, entitiesNew);
            try
            {
                await _unitOffWork.BeginTransactionAsync();
                var response = await _repository.CreateAsync(entitiesNew);
                var effectedCount = await _unitOffWork.SaveChangesAsync();
                if (effectedCount <= 0)
                {
                    throw new NullReferenceException();
                }
                var result = _mapper.Map<IEnumerable<TViewModel>>(response);
                await _unitOffWork.CommitTransactionAsync();
                return result;
            }
            catch (NullReferenceException)
            {
                await _unitOffWork.RollbackTransactionAsync();
                throw;
            }
            catch (Exception)
            {
                await _unitOffWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}

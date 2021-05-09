using MaxV.Base;
using App.Repositories.BaseRepository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Base
{
    public class BaseService<T, TRequest, TNonRequest> : IBaseService<T, TRequest, TNonRequest> where T : BaseEntity
    {
        public IBaseRepository<T> _repository;
        public readonly IMapper _mapper;
        public BaseService(IBaseRepository<T> baseRepository, IMapper mapper)
        {
            _repository = baseRepository;
            _mapper = mapper;
        }

        public async Task<int> DeleteHardAsync(int id)
        {
            return await _repository.DeleteHardAsync(id);
        }

        public async Task<int> DeleteSoftAsync(int id)
        {
            return await _repository.DeleteSoftAsync(id);
        }

        public async Task<IEnumerable<TNonRequest>> GetAllDTOAsync()
        {
            var entities = await _repository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<TNonRequest>>(entities);
            return result;
        }

        public async Task<TNonRequest> GetByUuidDTOAsync(int id)
        {
            var entity = await _repository.GetByIdNoTrackingAsync(id);
            var result = _mapper.Map<TNonRequest>(entity);
            return result;
        }

        public virtual async Task<TNonRequest> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            var result = _mapper.Map<TNonRequest>(entity);
            return result;
        }
    }
}

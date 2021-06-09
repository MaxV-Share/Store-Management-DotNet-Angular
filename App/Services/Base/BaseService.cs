using MaxV.Base;
using App.Repositories.BaseRepository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Base
{
    public class BaseService<T, TCreateRequest, TViewModel, TKey> : IBaseService<T, TCreateRequest, TViewModel, TKey> where T : BaseEntity<TKey>
    {
        public IBaseRepository<T, TKey> _repository;
        public readonly IMapper _mapper;
        public BaseService(IBaseRepository<T, TKey> baseRepository, IMapper mapper)
        {
            _repository = baseRepository;
            _mapper = mapper;
        }

        public async Task<int> DeleteHardAsync(TKey id)
        {
            return await _repository.DeleteHardAsync(id);
        }

        public async Task<int> DeleteSoftAsync(TKey id)
        {
            return await _repository.DeleteSoftAsync(id);
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
    }
}

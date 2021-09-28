using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Base
{
    public interface IBaseService<T, TCreateRequest, TUpdateRequest, TViewModel, TKey>
    {
        Task<IEnumerable<TViewModel>> GetAllDTOAsync();
        Task<TViewModel> GetByIdAsync(TKey id);
        Task<int> DeleteHardAsync(TKey id);
        Task<int> DeleteSoftAsync(TKey id);
        public Task<int> UpdateAsync(TKey id, TUpdateRequest request);
        Task<TViewModel> CreateAsync(TCreateRequest request);
        Task<IEnumerable<TViewModel>> CreateAsync(IEnumerable<TCreateRequest> request);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Base
{
    public interface IBaseService<T, TCreateRequest, TViewModel, TKey>
    {
        public Task<IEnumerable<TViewModel>> GetAllDTOAsync();
        public Task<TViewModel> GetByIdAsync(TKey id);
        public Task<int> DeleteHardAsync(TKey id);
        public Task<int> DeleteSoftAsync(TKey id);
    }
}

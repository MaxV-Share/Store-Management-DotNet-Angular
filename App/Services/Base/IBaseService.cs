using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Base
{
    public interface IBaseService<T, TRequest, TNonRequest>
    {
        public Task<IEnumerable<TNonRequest>> GetAllDTOAsync();
        public Task<TNonRequest> GetByIdAsync(int id);
        public Task<TNonRequest> GetByUuidDTOAsync(int id);
        public Task<int> DeleteHardAsync(int id);
        public Task<int> DeleteSoftAsync(int id);
    }
}

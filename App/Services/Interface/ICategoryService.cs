using App.Models.DTOs;
using App.Models.Entities;
using App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface ICategoryService : IBaseService<Category, CategoryRequest, CategoryNonRequest>
    {
        public Task<CategoryNonRequest> PostAsync(CategoryRequest request);
        public Task<int> PutAsync(int id, CategoryNonRequest request);
    }
}

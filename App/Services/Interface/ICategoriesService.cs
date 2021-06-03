using App.Models.DTOs;
using App.Models.Entities;
using App.Services.Base;
using MaxV.Helper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface ICategoriesService : IBaseService<Category, CategoryCR, CategoryVm, int>
    {
        Task<CategoryVm> CreateAsync(CategoryCR request);
        Task<int> PutAsync(int id, CategoryVm request);
        Task<List<CategoryDetailVm>> GetPaging(string langId, int pageIndex, int pageSize, string searchText);
    }
}

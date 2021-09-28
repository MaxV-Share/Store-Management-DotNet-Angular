using App.Models.DTOs;
using App.Models.DTOs.PagingViewModels;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Base;
using MaxV.Helper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface ICategoryService : IBaseService<Category, CategoryCreateRequest, CategoryUpdateRequest, CategoryViewModel, int>
    {
        Task<CategoryViewModel> CreateAsync(CategoryCreateRequest request);
        Task<CategoryDetailPaging> GetDetailsPagingAsync(string langId, int pageIndex, int pageSize, string searchText);
        Task<IEnumerable<CategoryDetailViewModel>> GetAllDTOAsync(string langId, string searchText);
    }
}

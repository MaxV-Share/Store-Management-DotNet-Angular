using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.PagingViewModels;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Models.DTOs.Categories;

namespace App.Services.Interface
{
    public interface ICategoryService : IBaseService<Category, CategoryCreateRequest, CategoryUpdateRequest, CategoryViewModel, int>
    {
        Task<CategoryDetailPaging> GetPagingAsync(string langId, int pageIndex, int pageSize, string searchText);
        Task<IEnumerable<CategoryDetailViewModel>> GetAllDTOAsync(string langId, string searchText);
    }
}

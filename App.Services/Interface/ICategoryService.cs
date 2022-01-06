using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Models.DTOs.Categories;
using App.Models.DTOs.CategoryDetails;
using App.Common.Model.DTOs;
using App.Common.Model;

namespace App.Services.Interface
{
    public interface ICategoryService : IBaseService<Category, CategoryCreateRequest, CategoryUpdateRequest, CategoryViewModel, int>
    {
        Task<IBasePaging<CategoryDetailViewModel>> GetPagingAsync(IFilterBodyRequest request);
    }
}

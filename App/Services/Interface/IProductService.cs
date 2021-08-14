using App.Models.DTOs;
using App.Models.DTOs.PagingViewModels;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IProductService : IBaseService<Product, ProductCreateRequest, ProductUpdateRequest, ProductViewModel, int>
    {
        Task<int> UpdateAsync(int id, ProductViewModel request);
        Task<ProductDetailPaging> GetPagingAsync(string langId, int pageIndex, int pageSize, string searchText);
        Task<IEnumerable<ProductDetailViewModel>> GetAllDTOAsync(string langId, string searchText);
    }
}

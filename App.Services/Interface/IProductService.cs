﻿using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Base;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Models.DTOs.ProductDetails;
using App.Models.DTOs.Products;
using App.Common.Model.DTOs;
using App.Common.Model;

namespace App.Services.Interface
{
    public interface IProductService : IBaseService<Product, ProductCreateRequest, ProductUpdateRequest, ProductViewModel, int>
    {
        Task<int> UpdateAsync(int id, ProductViewModel request);
        Task<IBasePaging<ProductDetailViewModel>> GetPagingAsync(FilterBodyRequest request);
        Task ImportProducts(IFormFile file);
    }
}

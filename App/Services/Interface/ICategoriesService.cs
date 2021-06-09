﻿using App.Models.DTOs;
using App.Models.DTOs.Paging;
using App.Models.Entities;
using App.Services.Base;
using MaxV.Helper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface ICategoriesService : IBaseService<Category, CategoryCreateRequest, CategoryViewModel, int>
    {
        Task<CategoryViewModel> CreateAsync(CategoryCreateRequest request);
        Task<int> PutAsync(int id, CategoryViewModel request);
        Task<CategoryDetailPaging> GetPaging(string langId, int pageIndex, int pageSize, string searchText);
        Task<IEnumerable<CategoryDetailViewModel>> GetAllDTOAsync(string langId);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using App.Common.Model;
using App.Common.Model.DTOs;

namespace App.Services.Base
{
    public interface IBaseService<TEntity, TCreateRequest, TUpdateRequest, TViewModel, TKey>
        where TEntity : class, new()
        where TCreateRequest : BaseCreateRequest, new()
        where TUpdateRequest : BaseUpdateRequest<TKey>, new()
        where TViewModel : BaseViewModel<TKey>, new()
    {
        Task<IEnumerable<TViewModel>> GetAllDTOAsync();
        Task<TViewModel> GetByIdAsync(TKey id);
        Task<int> DeleteHardAsync(TKey id);
        Task<int> DeleteSoftAsync(TKey id);
        public Task<int> UpdateAsync(TKey id, TUpdateRequest request);
        Task<TViewModel> CreateAsync(TCreateRequest request);
        Task<IEnumerable<TViewModel>> CreateAsync(IEnumerable<TCreateRequest> request);
    }
}

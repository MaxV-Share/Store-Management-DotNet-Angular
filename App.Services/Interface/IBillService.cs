﻿using App.Common.Model;
using App.Common.Model.DTOs;
using App.Models.DTOs.Bills;
using App.Models.DTOs.CreateRequests;
using App.Models.Entities;
using App.Services.Base;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IBillService : IBaseService<Bill, BillCreateRequest, BillUpdateRequest, BillViewModel, int>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<int> UpdateAsync(int id, BillViewModel request);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IBasePaging<BillViewModel>> GetPagingAsync(IFilterBodyRequest request);
    }
}

﻿using App.Models.DTOs;
using App.Models.DTOs.Bills;
using App.Models.DTOs.CreateRequest;
using App.Models.Entities;
using App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IBillDetailService : IBaseService<BillDetail, BillDetailCreateRequest, BillDetailViewModel, int>
    {
        Task<IEnumerable<BillDetailViewModel>> GetByBillIdAsync(int id, string langId);
    }
}
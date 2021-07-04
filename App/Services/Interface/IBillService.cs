using App.Models.DTOs;
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
    public interface  IBillService : IBaseService<Bill, BillCreateRequest, BillViewModel, int>
    { 
        Task<BillViewModel> CreateAsync(BillCreateRequest request);
        Task<int> UpdateAsync(int id, BillViewModel request);
        Task<IEnumerable<BillViewModel>> GetPaging(int pageIndex, int pageSize);
    }
}

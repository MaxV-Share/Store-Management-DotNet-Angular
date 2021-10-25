using App.Models.DTOs.Bills;
using App.Models.DTOs.CreateRequests;
using App.Models.Entities;
using App.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IBillDetailService : IBaseService<BillDetail, BillDetailCreateRequest, BillDetailUpdateRequest, BillDetailViewModel, int>
    {
        Task<IEnumerable<BillDetailViewModel>> GetByBillIdAsync(int id, string langId);
    }
}

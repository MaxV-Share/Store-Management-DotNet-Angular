using App.Models.DTOs.Bills;
using App.Models.DTOs.CreateRequests;
using App.Models.Entities;
using App.Services.Base;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IBillService : IBaseService<Bill, BillCreateRequest, BillUpdateRequest, BillViewModel, int>
    {
        Task<int> UpdateAsync(int id, BillViewModel request);
        Task<BillPaging> GetPagingAsync(int pageIndex, int pageSize, string txtSearch);
    }
}

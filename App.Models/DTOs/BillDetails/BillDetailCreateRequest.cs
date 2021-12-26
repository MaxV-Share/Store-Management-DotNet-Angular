using MaxV.Common.Model.DTOs;
using App.Models.DTOs.CreateRequests;

namespace App.Models.DTOs.BillDetails
{
    public class BillDetailCreateRequest : BaseCreateRequest
    {
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public double? DiscountPrice { get; set; }
    }
}

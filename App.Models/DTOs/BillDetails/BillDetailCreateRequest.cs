using App.Models.DTOs.CreateRequests;
using App.Common.Model.DTOs;

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

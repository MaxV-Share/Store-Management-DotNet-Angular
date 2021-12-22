using MaxV.Base.DTOs;

namespace App.Models.DTOs.CreateRequests
{
    public class BillDetailCreateRequest : BaseCreateRequest
    {
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public double? DiscountPrice { get; set; }
    }
}

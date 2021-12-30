using App.Models.DTOs.Bills;
using App.Common.Model.DTOs;

namespace App.Models.DTOs.BillDetails
{
    public class BillDetailViewModel : BaseViewModel<int>
    {
        public int BillId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public double? DiscountPrice { get; set; }
        public int ProductId { get; set; }
        public ProductInBillViewModel Product { get; set; }
    }
}

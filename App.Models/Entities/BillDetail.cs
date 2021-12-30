using App.Common.Model;

namespace App.Models.Entities
{
    public class BillDetail : BaseEntity<int>
    {
        public virtual Bill Bill { get; set; }
        public int BillId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public double? DiscountPrice { get; set; }
    }
}

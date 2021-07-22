using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs.Bills
{
    public class BillDetailViewModel : BaseDTOViewModel<int>
    {
        public int BillId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public double? DiscountPrice { get; set; }
        public int ProductId { get; set; }
        public ProductInBillViewModel Product { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs.CreateRequest
{
    public class BillDetailCreateRequest
    {
        public int ProductId { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public double? DiscountPrice { get; set; }
    }
}

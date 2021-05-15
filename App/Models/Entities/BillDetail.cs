using MaxV.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entities
{
    public class BillDetail : BaseEntity
    {
        public Bill Bill { get; set; }
        public Product Product { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public double? Price { get; set; }
        public double? DiscountPrice { get; set; }
    }
}

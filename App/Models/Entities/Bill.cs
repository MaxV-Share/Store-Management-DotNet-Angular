using MaxV.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entities
{
    public class Bill : BaseEntity<int>
    {
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual User UserPayment { get; set; }
        public string UserPaymentId { get; set; }
        public double? TotalPrice { get; set; }
        public double? DiscountPrice { get; set; }
        public virtual IEnumerable<BillDetail> BillDetails { get; set; }
    }
}

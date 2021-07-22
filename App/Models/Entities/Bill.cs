using App.Models.Entities.Identities;
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
        public override void SetValueUpdate(string updateAt)
        {
            BillDetails.ToList().ForEach(e => e.SetValueUpdate(updateAt));
            base.SetValueUpdate(updateAt);
        }
        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public virtual User UserPayment { get; set; }
        public string UserPaymentId { get; set; }
        public double? TotalPrice { get; set; }
        public double? DiscountPrice { get; set; }
        public double? PaymentAmount { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}

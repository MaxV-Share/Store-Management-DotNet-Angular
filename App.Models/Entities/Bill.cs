﻿using App.Models.Entities.Identities;
using System.Collections.Generic;
using System.Linq;
using MaxV.Common.Model;

namespace App.Models.Entities
{
    public class Bill : BaseEntity<int>
    {
        public override Bill SetValueUpdate(string updateAt)
        {
            BillDetails.ToList().ForEach(e => e.SetValueUpdate(updateAt));
            base.SetValueUpdate(updateAt);
            return this;
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

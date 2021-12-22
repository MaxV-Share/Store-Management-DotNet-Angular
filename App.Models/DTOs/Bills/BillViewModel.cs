using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;

namespace App.Models.DTOs.Bills
{
    public class BillViewModel : BaseViewModel<int>
    {
        public string CustomerPhoneNumber { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime? CustomerBirthday { get; set; }
        public string UserPaymentId { get; set; }
        public string UserPaymentUserName { get; set; }
        public double? TotalPrice { get; set; }
        public double? DiscountPrice { get; set; }
        public double? PaymentAmount { get; set; }
        public List<BillDetailViewModel> billDetails { get; set; }
    }
}

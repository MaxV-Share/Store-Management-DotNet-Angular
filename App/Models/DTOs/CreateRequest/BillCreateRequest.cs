using App.Models.DTOs.CreateRequest;
using App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs.CreateRequest
{
    public class BillCreateRequest
    {
        public int? CustomerId { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime? CustomerBirthday { get; set; }
        public string UserPaymentId { get; set; }
        public string UserPaymentUserName { get; set; }
        public double? TotalPrice { get; set; }
        public double? DiscountPrice { get; set; }
        public double? PaymentAmount { get; set; }
        public IEnumerable<BillDetailCreateRequest> BillDetails { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Models.DTOs.BillDetails;
using App.Models.DTOs.CreateRequests;
using App.Common.Model.DTOs;

namespace App.Models.DTOs.Bills
{
    public class BillCreateRequest : BaseCreateRequest
    {
        public int? CustomerId { get; set; }
        [MaxLength(10)]
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

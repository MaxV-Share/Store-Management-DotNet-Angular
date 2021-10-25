using MaxV.Base.DTOs;
using System;

namespace App.DTOs
{
    public class DiscountCreateRequest : BaseCreateRequest
    {
        public int? PercentDiscount { get; set; }
        public double? MaxDiscountPrice { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}

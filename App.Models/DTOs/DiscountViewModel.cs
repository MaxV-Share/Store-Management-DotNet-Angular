using System;
using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs
{
    public class DiscountViewModel : BaseViewModel<int>
    {
        public int? PercentDiscount { get; set; }
        public double? MaxDiscountPrice { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}

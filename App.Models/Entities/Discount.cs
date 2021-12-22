using MaxV.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace App.Models.Entities
{
    public class Discount : BaseEntity<int>
    {
        [Range(0, 100)]
        public int? PercentDiscount { get; set; }
        public double? MaxDiscountPrice { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}

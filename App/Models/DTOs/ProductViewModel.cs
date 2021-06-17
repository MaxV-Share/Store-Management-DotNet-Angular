using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class ProductViewModel : BaseDTO<int>
    {
        public int CategoryId { get; set; }
        [MaxLength(256)]
        public string Code { get; set; }
        public double? Price { get; set; }
        [Range(0, 100)]
        public int? PercentDiscount { get; set; }
        public double? MaxDiscountPrice { get; set; }
        public string ImageUrl { get; set; }
        public virtual List<ProductDetailViewModel> ProductDetails { get; set; }
    }
}

using MaxV.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entities
{
    public class Product : BaseEntity<int>
    {
        public override void SetDefaultValue(string createAt)
        {
            base.SetDefaultValue(createAt);
            ProductDetails.ForEach(e =>
            {
                e.SetDefaultValue(createAt);
            });
        }
        public override void SetValueUpdate(string updateAt)
        {
            base.SetDefaultValue(updateAt);
            ProductDetails.ForEach(e =>
            {
                e.SetValueUpdate(updateAt);
            });
        }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        [MaxLength(256)]
        public string Code { get; set; }
        public double? Price { get; set; }
        [Range(0, 100)]
        public int? PercentDiscount { get; set; }
        public double? MaxDiscountPrice { get; set; }
        public string ImageUrl { get; set; }
        public virtual List<ProductDetail> ProductDetails { get; set; }
    }
}

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
        public override void SetDefaultValue()
        {
            base.SetDefaultValue();
            ProductDetails.ForEach(e =>
            {
                e.CreateBy = CreateBy;
                e.SetDefaultValue();
            });
        }
        public override void SetValueUpdate()
        {
            base.SetDefaultValue();
            ProductDetails.ForEach(e =>
            {
                e.UpdateBy = UpdateBy;
                e.SetValueUpdate();
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

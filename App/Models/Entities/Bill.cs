using MaxV.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entities
{
    public class Bill : BaseEntity
    {
        public Customer Customer { get; set; } 
        public User UserPayment { get; set; }
        public double? TotalPrice { get; set; }
        public double? DiscountPrice { get; set; }
    }
}

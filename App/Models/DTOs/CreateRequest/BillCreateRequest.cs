﻿using App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class BillCreateRequest
    {
        public Customer Customer { get; set; }
        public User UserPayment { get; set; }
        public double? TotalPrice { get; set; }
        public double? DiscountPrice { get; set; }
    }
}
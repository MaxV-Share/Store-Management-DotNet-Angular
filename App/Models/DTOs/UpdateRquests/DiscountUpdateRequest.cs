﻿using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs.UpdateRquests
{
    public class DiscountUpdateRequest : BaseDTOUpdateRequest<int>
    {
        public int? PercentDiscount { get; set; }
        public double? MaxDiscountPrice { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaxV.Base.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.DTOs
{
    public class DiscountCreateRequest : BaseDTOCreateRequest
    {
        public int? PercentDiscount { get; set; }
        public double? MaxDiscountPrice { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}

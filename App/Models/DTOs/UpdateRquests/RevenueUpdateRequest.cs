using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs.UpdateRquests
{
    public class RevenueUpdateRequest : BaseDTOUpdateRequest<int>
    {
        public string Id { get; set; }
        public double TotalPrice { get; set; }
    }
}

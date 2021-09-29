using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs.UpdateRquests
{
    public class RevenueUpdateRequest : BaseUpdateRequest<string>
    {
        public double TotalPrice { get; set; }
    }
}

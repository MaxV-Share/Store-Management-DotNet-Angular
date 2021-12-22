using MaxV.Base.DTOs;

namespace App.Models.DTOs.UpdateRquests
{
    public class RevenueUpdateRequest : BaseUpdateRequest<string>
    {
        public double TotalPrice { get; set; }
    }
}

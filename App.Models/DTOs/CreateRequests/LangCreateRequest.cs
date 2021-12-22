using System.ComponentModel.DataAnnotations;
using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs.CreateRequests
{
    public class LangCreateRequest : BaseCreateRequest
    {
        [MaxLength(10)]
        public string Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public int Order { get; set; }
    }
}

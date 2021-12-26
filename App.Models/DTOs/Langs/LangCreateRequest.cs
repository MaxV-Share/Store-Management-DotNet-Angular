using System.ComponentModel.DataAnnotations;
using MaxV.Common.Model.DTOs;
using App.Models.DTOs.CreateRequests;

namespace App.Models.DTOs.Langs
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

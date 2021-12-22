using System.ComponentModel.DataAnnotations;
using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs.CreateRequests
{
    public class CommandCreateRequest : BaseCreateRequest
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

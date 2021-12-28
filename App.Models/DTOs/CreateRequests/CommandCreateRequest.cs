using System.ComponentModel.DataAnnotations;
using App.Common.Model.DTOs;

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

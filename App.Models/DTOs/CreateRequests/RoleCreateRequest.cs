using System.ComponentModel.DataAnnotations;
using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs.CreateRequests
{
    public class RoleCreateRequest : BaseCreateRequest
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

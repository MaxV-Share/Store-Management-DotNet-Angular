using MaxV.Base.DTOs;
using System.ComponentModel.DataAnnotations;

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

using System.ComponentModel.DataAnnotations;
using App.Common.Model.DTOs;

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

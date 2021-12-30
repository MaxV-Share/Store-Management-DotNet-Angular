using System.ComponentModel.DataAnnotations;
using App.Common.Model.DTOs;

namespace App.Models.DTOs.UpdateRquests
{
    public class RoleUpdateRequest : BaseUpdateRequest<string>
    {
        [Required]
        public string Name { get; set; }
    }
}

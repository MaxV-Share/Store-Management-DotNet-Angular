using MaxV.Base.DTOs;
using System.ComponentModel.DataAnnotations;

namespace App.Models.DTOs.UpdateRquests
{
    public class CategoryUpdateRequest : BaseUpdateRequest<int>
    {
        [Required]
        public string Name { get; set; }
    }
}

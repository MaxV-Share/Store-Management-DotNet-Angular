using System.ComponentModel.DataAnnotations;
using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs.UpdateRquests
{
    public class CategoryUpdateRequest : BaseUpdateRequest<int>
    {
        [Required]
        public string Name { get; set; }
    }
}

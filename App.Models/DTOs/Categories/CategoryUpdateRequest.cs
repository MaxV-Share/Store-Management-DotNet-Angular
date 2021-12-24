using System.ComponentModel.DataAnnotations;
using MaxV.Common.Model.DTOs;
using App.Models.DTOs.UpdateRquests;

namespace App.Models.DTOs.Categories
{
    public class CategoryUpdateRequest : BaseUpdateRequest<int>
    {
        [Required]
        public string Name { get; set; }
    }
}

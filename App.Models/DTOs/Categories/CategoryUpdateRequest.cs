using System.ComponentModel.DataAnnotations;
using App.Models.DTOs.UpdateRquests;
using App.Common.Model.DTOs;

namespace App.Models.DTOs.Categories
{
    public class CategoryUpdateRequest : BaseUpdateRequest<int>
    {
        [Required]
        public string Name { get; set; }
    }
}

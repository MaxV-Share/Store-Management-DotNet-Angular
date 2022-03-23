using System.ComponentModel.DataAnnotations;
using App.Models.DTOs.UpdateRquests;
using App.Common.Model.DTOs;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using App.Models.DTOs.CategoryDetails;

namespace App.Models.DTOs.Categories
{
    public class CategoryUpdateRequest : BaseUpdateRequest<int>
    {
        [JsonProperty(PropertyName = "details")]
        [FromForm(Name = "details")]
        public List<CategoryDetailUpdateRequest> CategoryDetails { get; set; }
        public int? ParentId { get; set; }
    }
}

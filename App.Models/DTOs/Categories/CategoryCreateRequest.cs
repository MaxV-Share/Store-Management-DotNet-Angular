using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.CategoryDetails;
using App.Common.Model.DTOs;

namespace App.Models.DTOs.Categories
{
    public class CategoryCreateRequest : BaseCreateRequest
    {
        [JsonProperty(PropertyName = "details")]
        [FromForm(Name = "details")]
        public List<CategoryDetailCreateRequest> CategoryDetails { get; set; }
        public int? ParentId { get; set; }
    }
}

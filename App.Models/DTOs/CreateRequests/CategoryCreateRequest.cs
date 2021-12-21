using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs.CreateRequests
{
    public class CategoryCreateRequest : BaseCreateRequest
    {
        [JsonProperty(PropertyName = "details")]
        [FromForm(Name = "details")]
        public List<CategoryDetailCreateRequest> CategoryDetails { get; set; }
        public int? ParentId { get; set; }
    }
}

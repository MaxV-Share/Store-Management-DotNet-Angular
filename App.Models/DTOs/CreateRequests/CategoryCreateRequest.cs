using MaxV.Base.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace App.Models.DTOs.CreateRequests
{
    public class CategoryCreateRequest : BaseCreateRequest
    {
        [JsonProperty(PropertyName = "details")]
        public List<CategoryDetailCreateRequest> CategoryDetails { get; set; }
        public int? ParentId { get; set; }
    }
}

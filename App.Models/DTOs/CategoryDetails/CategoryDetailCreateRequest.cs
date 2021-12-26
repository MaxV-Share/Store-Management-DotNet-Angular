using Newtonsoft.Json;
using MaxV.Common.Model.DTOs;
using App.Models.DTOs.CreateRequests;

namespace App.Models.DTOs.CategoryDetails
{
    public class CategoryDetailCreateRequest : BaseCreateRequest
    {
        [JsonProperty(PropertyName = "langId", Required = Required.Always)]
        public string LangId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

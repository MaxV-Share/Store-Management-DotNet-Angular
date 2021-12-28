using Newtonsoft.Json;
using App.Models.DTOs.CreateRequests;
using App.Common.Model.DTOs;

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

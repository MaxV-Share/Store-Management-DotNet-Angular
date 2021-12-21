using Newtonsoft.Json;
using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs.CreateRequests
{
    public class CategoryDetailCreateRequest : BaseCreateRequest
    {
        [JsonProperty(PropertyName = "langId", Required = Required.Always)]
        public string LangId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

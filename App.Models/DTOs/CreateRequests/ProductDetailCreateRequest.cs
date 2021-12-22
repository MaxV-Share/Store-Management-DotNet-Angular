using Newtonsoft.Json;
using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs.CreateRequests
{
    public class ProductDetailCreateRequest : BaseCreateRequest
    {
        [JsonProperty(PropertyName = "langId", Required = Required.Always)]
        public string LangId { get; set; }
        [JsonRequired]
        public string Name { get; set; }
        [JsonRequired]
        public string Description { get; set; }
    }
}

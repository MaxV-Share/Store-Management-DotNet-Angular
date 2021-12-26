using Newtonsoft.Json;
using MaxV.Common.Model.DTOs;
using App.Models.DTOs.CreateRequests;

namespace App.Models.DTOs.ProductDetails
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

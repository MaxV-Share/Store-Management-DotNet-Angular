using MaxV.Base.DTOs;
using Newtonsoft.Json;

namespace App.Models.DTOs
{
    public class CategoryDetailCreateRequest : BaseCreateRequest
    {
        [JsonProperty(PropertyName = "langId", Required = Required.Always)]
        public string LangId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

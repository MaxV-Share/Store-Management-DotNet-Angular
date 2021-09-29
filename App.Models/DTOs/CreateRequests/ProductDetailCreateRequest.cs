using MaxV.Base.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs.CreateRequest
{
    public class ProductDetailCreateRequest
    {
        [JsonProperty(PropertyName = "langId", Required = Required.Always)]
        public string LangId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

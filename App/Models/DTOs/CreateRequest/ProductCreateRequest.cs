using App.Models.DTOs.CreateRequest;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class ProductCreateRequest
    {
        [JsonProperty("categoryId")]
        public int CategoryId{ get; set; }
        public string Name { get; set; }
        [JsonProperty("file")]
        public IFormFile File{ get; set; }
        [JsonProperty("details")]
        public List<ProductDetailCreateRequest> CategoryDetails { get; set; }
    }
}

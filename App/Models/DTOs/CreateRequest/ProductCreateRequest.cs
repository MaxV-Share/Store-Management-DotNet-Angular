using App.Models.DTOs.CreateRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [JsonProperty("file")]
        public IFormFile File{ get; set; }
        [JsonProperty("details")]
        [FromForm(Name = "details")]
        public List<ProductDetailCreateRequest> ProductDetails { get; set; }
    }
}

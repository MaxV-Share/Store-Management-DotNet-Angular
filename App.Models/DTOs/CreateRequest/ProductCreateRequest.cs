﻿using App.Models.DTOs.CreateRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class ProductCreateRequest
    {
        [JsonProperty("categoryId")]
        public int CategoryId{ get; set; }
        [JsonProperty("name")]
        public string Name{ get; set; }
        public string Description { get; set; }
        [MaxLength(256)]
        public string Code { get; set; }
        public double? Price { get; set; }
        [JsonProperty("file")]
        public IFormFile File { get; set; }
        [JsonProperty("details")]
        [FromForm(Name = "details")]
        public List<ProductDetailCreateRequest> ProductDetails { get; set; }
    }
}
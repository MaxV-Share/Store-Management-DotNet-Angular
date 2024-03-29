﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Models.DTOs.ProductDetails;
using App.Models.DTOs.CreateRequests;
using App.Common.Model.DTOs;

namespace App.Models.DTOs.Products
{
    public class ProductCreateRequest : BaseCreateRequest
    {
        public int CategoryId { get; set; }
        public string Description { get; set; }
        [MaxLength(256)]
        public string Code { get; set; }
        public double? Price { get; set; }
        public string ImageUrl { get; set; }
        [JsonProperty("file")]
        [FromForm(Name = "file")]
        public IFormFile File { get; set; }
        [JsonProperty("details")]
        [FromForm(Name = "details")]
        [Required]
        public List<ProductDetailCreateRequest> ProductDetails { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MaxV.Common.Model.DTOs;
using App.Models.DTOs.ProductDetails;
using App.Models.DTOs.UpdateRquests;

namespace App.Models.DTOs.Products
{
    public class ProductUpdateRequest : BaseUpdateRequest<int>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [MaxLength(256)]
        public string Code { get; set; }
        public double? Price { get; set; }
        [Range(0, 100)]
        public int? PercentDiscount { get; set; }
        public double? MaxDiscountPrice { get; set; }
        public string ImageUrl { get; set; }
        [JsonProperty("file")]
        public IFormFile File { get; set; }
        [JsonProperty("details")]
        [FromForm(Name = "details")]
        public virtual List<ProductDetailUpdateRequest> ProductDetails { get; set; }
        public string Name { get; set; }
    }
}

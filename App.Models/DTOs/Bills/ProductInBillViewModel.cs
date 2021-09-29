using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs.Bills
{
    public class ProductInBillViewModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("uuid")]
        public Guid Uuid { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("price")]
        public double? Price { get; set; }
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty("detail")]
        public ProductDetailViewModel Detail { get; set; } 
        [MaxLength(256)]
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }
        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }
    }
}

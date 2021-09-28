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
        public int ProductId { get; set; }
        [JsonProperty("uuid")]
        public Guid ProductUuid { get; set; }
        [JsonProperty("code")]
        public string ProductCode { get; set; }
        [JsonProperty("price")]
        public double? ProductPrice { get; set; }
        [JsonProperty("imageUrl")]
        public string ProductImageUrl { get; set; }
        public string LangId { get; set; }
        [MaxLength(256)]
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }
        [JsonProperty("categoryId")]
        public int CategoryId { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}

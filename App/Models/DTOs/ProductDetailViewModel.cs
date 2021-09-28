using MaxV.Base.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class ProductDetailViewModel : BaseViewModel<int>
    {
        public int ProductId { get; set; }
        [JsonProperty("code")]
        public string ProductCode { get; set; }
        [JsonProperty("price")]
        public double? ProductPrice { get; set; }
        [JsonProperty("imageUrl")]
        public string ProductImageUrl { get; set; }
        public string LangId { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

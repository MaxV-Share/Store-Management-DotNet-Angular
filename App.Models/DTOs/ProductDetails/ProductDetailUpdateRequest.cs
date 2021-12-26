using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using MaxV.Common.Model.DTOs;
using App.Models.DTOs.UpdateRquests;

namespace App.Models.DTOs.ProductDetails
{
    public class ProductDetailUpdateRequest : BaseUpdateRequest<int>
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

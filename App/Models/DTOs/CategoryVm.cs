using MaxV.Base.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class CategoryVm : BaseDTO<int>
    {
        [JsonPropertyName("parent")]
        [JsonRequired]
        public int ParentId { get; set; }
        public List<CategoryDetailVm> categoryDetails { get; set; } 
    }
}

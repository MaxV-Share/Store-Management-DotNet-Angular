using MaxV.Base.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class CategoryViewModel : BaseDTOViewModel<int>
    {
        public int? ParentId { get; set; }
        [JsonProperty("details")]
        public List<CategoryDetailViewModel> CategoryDetails { get; set; } 
    }
}

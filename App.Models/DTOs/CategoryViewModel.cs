using Newtonsoft.Json;
using System.Collections.Generic;
using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs
{
    public class CategoryViewModel : BaseViewModel<int>
    {
        public int? ParentId { get; set; }
        [JsonProperty("details")]
        public List<CategoryDetailViewModel> CategoryDetails { get; set; }
    }
}

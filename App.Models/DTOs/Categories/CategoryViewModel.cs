using Newtonsoft.Json;
using System.Collections.Generic;
using App.Models.DTOs;
using App.Models.DTOs.CategoryDetails;
using App.Common.Model.DTOs;

namespace App.Models.DTOs.Categories
{
    public class CategoryViewModel : BaseViewModel<int>
    {
        public int? ParentId { get; set; }
        [JsonProperty("details")]
        public List<CategoryDetailViewModel> CategoryDetails { get; set; }
    }
}

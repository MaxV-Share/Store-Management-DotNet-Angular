using App.Models.Entities;
using MaxV.Base.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class CategoryCreateRequest : BaseDTOCreateRequest
    {
        [JsonProperty(PropertyName = "details")]
        public List<CategoryDetailCreateRequest> CategoryDetails { get; set; }
        public int? ParentId { get; set; }
    }
}

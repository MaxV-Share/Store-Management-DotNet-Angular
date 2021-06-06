using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class CategoryCR
    {
        [JsonPropertyName("details")]
        public List<CategoryDetailCR> CategoryDetails { get; set; }
    }
}

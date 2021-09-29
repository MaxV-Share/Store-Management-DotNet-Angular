using MaxV.Base.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class CategoryDetailCreateRequest : BaseCreateRequest
    {
        [JsonProperty(PropertyName = "langId", Required = Required.Always)]
        public string LangId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

using App.Common.Model.DTOs;
using App.Models.DTOs.FunctionDetails;
using App.Models.DTOs.UpdateRquests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Models.DTOs.Functions
{
    public class FunctionUpdateRequest : BaseUpdateRequest<string>
    {
        [Required]
        [FromForm(Name = "details")]
        public List<FunctionDetailUpdateRequest> Detail { get; set; }
        public string Url { get; set; }
        public int SortOrder { get; set; }
        public string Component { get; set; }
        public string Icon { get; set; }
        public string ParentId { get; set; }
    }
}

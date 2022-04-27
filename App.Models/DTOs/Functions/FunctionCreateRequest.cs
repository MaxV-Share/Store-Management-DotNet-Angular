using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Common.Model.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.FunctionDetails;
using Microsoft.AspNetCore.Mvc;

namespace App.Models.DTOs.Functions
{
    public class FunctionCreateRequest : BaseCreateRequest
    {
        public string Id { get; set; }
        [Required]
        [FromForm(Name = "details")]
        public List<FunctionDetailCreateRequest> Detail { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public int SortOrder { get; set; }
        [Required]
        public string Icon { get; set; }
        public string Component { get; set; }
        public string ParentId { get; set; }
    }
}

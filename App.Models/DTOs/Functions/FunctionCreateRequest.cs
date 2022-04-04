using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Common.Model.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.FunctionDetails;

namespace App.Models.DTOs.Functions
{
    public class FunctionCreateRequest : BaseCreateRequest
    {
        public string Id { get; set; }
        [Required]
        public List<FunctionDetailCreateRequest> Detail { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public int SortOrder { get; set; }
        public string ParentId { get; set; }
        [Required]
        public string Icon { get; set; }
    }
}

using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs.CreateRequests
{
    public class FunctionCreateRequest : BaseCreateRequest
    {
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public int SortOrder { get; set; }
        public string ParentId { get; set; }
        [Required]
        public string Icon { get; set; }
    }
}

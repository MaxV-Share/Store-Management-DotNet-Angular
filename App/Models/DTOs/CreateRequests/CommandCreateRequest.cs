using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs.CreateRequests
{
    public class CommandCreateRequest : BaseCreateRequest
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

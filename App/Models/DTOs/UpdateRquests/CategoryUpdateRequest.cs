using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs.UpdateRquests
{
    public class CategoryUpdateRequest : BaseUpdateRequest<int>
    {
        [Required]
        public string Name { get; set; }
    }
}

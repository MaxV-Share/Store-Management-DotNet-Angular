using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class CategoryVm : BaseDTO<int>
    {
        public int ParentId { get; set; }
        public List<CategoryDetailVm> categoryDetails { get; set; } 
    }
}

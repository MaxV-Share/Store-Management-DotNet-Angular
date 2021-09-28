using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class TreeFunctionViewModel
    {
        public FunctionViewModel Data { get; set; }
        public List<TreeFunctionViewModel> Children { get; set; }
        public bool? Expanded { get; set; }
    }
}

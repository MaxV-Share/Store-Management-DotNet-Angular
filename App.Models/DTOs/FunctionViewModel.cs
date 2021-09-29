using MaxV.Base.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using App.Models.Entities;

namespace App.Models.DTOs
{
    public class FunctionViewModel : BaseViewModel<string>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int SortOrder { get; set; }
        public string ParentId { get; set; }
        public List<FunctionViewModel> Childrens { get; set; } = new List<FunctionViewModel>();
        public string Icon { get; set; }
        public virtual ICollection<CommandInFunctionViewModel> CommandInFunctions { get; set; }
    }
}

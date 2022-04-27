using System.Collections.Generic;
using App.Common.Model.DTOs;
using App.Models.DTOs.Functions;
using App.Models.DTOs;

namespace App.Models.DTOs.Functions
{
    public class FunctionViewModel : BaseViewModel<string>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int SortOrder { get; set; }
        public string Icon { get; set; }
        public string Component { get; set; }
        public string ParentId { get; set; }
        //public List<FunctionViewModel> Childrens { get; set; } = new List<FunctionViewModel>();
        public virtual ICollection<CommandInFunctionViewModel> CommandInFunctions { get; set; }
    }
}

using App.Common.Model.DTOs;
using App.Models.DTOs.FunctionDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.DTOs.Functions
{
    public class FunctionFullViewModel : BaseViewModel<string>
    {
        public string Url { get; set; }
        public int SortOrder { get; set; }
        public string ParentId { get; set; }
        public string Icon { get; set; }
        public virtual ICollection<FunctionDetailViewModel> Detail { get; set; }
        public virtual ICollection<CommandInFunctionViewModel> CommandInFunctions { get; set; }
    }
}

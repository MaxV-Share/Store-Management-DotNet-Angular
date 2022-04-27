using App.Common.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.DTOs.FunctionDetails
{
    public class FunctionDetailViewModel : BaseViewModel<int>
    {
        public string LangId { get; set; }
        public int? LangOrder { get; set; }
        public string Name { get; set; }
        public string FunctionId { get; set; }
    }
}

using System;
using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs
{
    public class CommandInFunctionViewModel : BaseViewModel<Guid>
    {
        public string CommandId { get; set; }
        public string FunctionId { get; set; }
    }
}

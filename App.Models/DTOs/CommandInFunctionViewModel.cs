using MaxV.Base.DTOs;
using System;

namespace App.Models.DTOs
{
    public class CommandInFunctionViewModel : BaseViewModel<Guid>
    {
        public string CommandId { get; set; }
        public string FunctionId { get; set; }
    }
}

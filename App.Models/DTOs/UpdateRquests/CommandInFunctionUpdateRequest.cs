using MaxV.Base.DTOs;
using System;

namespace App.Models.DTOs.UpdateRquests
{
    public class CommandInFunctionUpdateRequest : BaseUpdateRequest<Guid>
    {
        public string CommandId { get; set; }
        public string FunctionId { get; set; }
    }
}

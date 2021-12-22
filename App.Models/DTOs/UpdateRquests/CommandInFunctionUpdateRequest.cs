using System;
using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs.UpdateRquests
{
    public class CommandInFunctionUpdateRequest : BaseUpdateRequest<Guid>
    {
        public string CommandId { get; set; }
        public string FunctionId { get; set; }
    }
}

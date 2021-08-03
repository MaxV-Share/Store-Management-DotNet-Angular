﻿using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs.UpdateRquests
{
    public class CommandInFunctionUpdateRequest : BaseUpdateRequest<Guid>
    {
        public string CommandId { get; set; }
        public string FunctionId { get; set; }
    }
}

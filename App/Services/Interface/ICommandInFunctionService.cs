using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.DTOs;
using App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.Entities;

namespace App.Services.Interface
{
    public interface ICommandInFunctionService : IBaseService<CommandInFunction, CommandInFunctionCreateRequest, CommandInFunctionUpdateRequest, CommandInFunctionViewModel, Guid>
    {
    }
}

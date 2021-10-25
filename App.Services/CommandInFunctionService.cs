using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Repositories.UnitOffWorks;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;

namespace App.Services
{
    public class CommandInFunctionService : BaseService<CommandInFunction, CommandInFunctionCreateRequest, CommandInFunctionUpdateRequest, CommandInFunctionViewModel, Guid>, ICommandInFunctionService
    {
        public CommandInFunctionService(IMapper mapper, IUnitOffWork unitOffWork, ILogger<CommandInFunctionService> logger) : base(mapper, unitOffWork, logger)
        {
        }
    }
}

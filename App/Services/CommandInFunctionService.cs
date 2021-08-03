using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.DTOs;
using App.Models.Entities;
using App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services.Interface;
using App.Repositories.BaseRepository;
using AutoMapper;
using App.Infrastructures.UnitOffWorks;
using Microsoft.Extensions.Logging;
using App.Repositories.Interface;

namespace App.Services
{
    public class CommandInFunctionService : BaseService<CommandInFunction, CommandInFunctionCreateRequest, CommandInFunctionUpdateRequest, CommandInFunctionViewModel, Guid>, ICommandInFunctionService
    {
        public CommandInFunctionService(ICommandInFunctionRepository repository, IMapper mapper, IUnitOffWork unitOffWork, ILogger<CommandInFunctionService> logger) : base(repository, mapper, unitOffWork, logger)
        {
        }
    }
}

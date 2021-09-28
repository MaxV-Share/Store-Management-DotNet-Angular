using App.Infrastructures.UnitOffWorks;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Repositories;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class CommandService : BaseService<Command, CommandCreateRequest, CommandUpdateRequest, CommandViewModel, string>, ICommandService
    {
        public CommandService(IMapper mapper, IUnitOffWork unitOffWork, ILogger<CommandService> logger) : base(mapper, unitOffWork, logger)
        {
        }
    }
}

using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Repositories.UnitOffWorks;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace App.Services
{
    public class CommandService : BaseService<Command, CommandCreateRequest, CommandUpdateRequest, CommandViewModel, string>, ICommandService
    {
        public CommandService(IMapper mapper, IUnitOffWork unitOffWork, ILogger<CommandService> logger) : base(mapper, unitOffWork, logger)
        {
        }
    }
}

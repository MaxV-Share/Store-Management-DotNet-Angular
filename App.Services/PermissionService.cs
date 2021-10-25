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
    public class PermissionService : BaseService<Permission, PermissionCreateRequest, PermissionUpdateRequest, PermissionViewModel, Guid>, IPermissionService
    {
        public PermissionService(IMapper mapper, IUnitOffWork unitOffWork, ILogger<PermissionService> logger) : base(mapper, unitOffWork, logger)
        {
        }
    }
}

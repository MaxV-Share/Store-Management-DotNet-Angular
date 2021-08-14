using App.Controllers.Base;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities.Identities;
using App.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class RolesController : CRUDContoller<Role,RoleCreateRequest,RoleUpdateRequest,RoleViewModel,string> 
    {
        public readonly IRoleService _roleService;
        public readonly IConfiguration _configuration;
        public RolesController(IRoleService roleService, IConfiguration configuration, ILogger<RolesController> logger) : base(logger, roleService)
        {
            _roleService = roleService;
            _configuration = configuration;
        }
    }
}

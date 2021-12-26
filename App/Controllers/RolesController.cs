using App.Controllers.Base;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities.Identities;
using App.Services.Interface;
using MaxV.Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class RolesController : CrudController<Role, RoleCreateRequest, RoleUpdateRequest, RoleViewModel, string>
    {
        public readonly IRoleService _roleService;
        public readonly IConfiguration _configuration;
        public RolesController(IRoleService roleService, IConfiguration configuration, ILogger<RolesController> logger) : base(logger, roleService)
        {
            _roleService = roleService;
            _configuration = configuration;
        }

        public override Task<ActionResult> GetPaging(FilterBodyRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}

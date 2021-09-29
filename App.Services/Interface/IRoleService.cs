using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities.Identities;
using App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IRoleService : IBaseService<Role,RoleCreateRequest,RoleUpdateRequest,RoleViewModel,string>
    {
    }
}

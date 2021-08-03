using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.DTOs;
using App.Models.Entities;
using App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IPermissionService : IBaseService<Permission, PermissionCreateRequest, PermissionUpdateRequest, PermissionViewModel, Guid>
    {
    }
}

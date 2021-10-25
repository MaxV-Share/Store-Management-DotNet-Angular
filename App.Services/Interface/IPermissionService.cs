using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Base;
using System;

namespace App.Services.Interface
{
    public interface IPermissionService : IBaseService<Permission, PermissionCreateRequest, PermissionUpdateRequest, PermissionViewModel, Guid>
    {
    }
}

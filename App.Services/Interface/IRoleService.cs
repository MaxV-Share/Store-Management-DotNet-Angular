using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities.Identities;
using App.Services.Base;

namespace App.Services.Interface
{
    public interface IRoleService : IBaseService<Role, RoleCreateRequest, RoleUpdateRequest, RoleViewModel, string>
    {
    }
}

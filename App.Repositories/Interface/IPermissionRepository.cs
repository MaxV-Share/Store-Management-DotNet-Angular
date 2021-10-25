using App.Models.Entities;
using App.Repositories.BaseRepository;
using System;

namespace App.Repositories.Interface
{
    public interface IPermissionRepository : IBaseRepository<Permission, Guid>
    {
    }
}

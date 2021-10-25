using App.Models.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using System;

namespace App.Repositories
{
    public class PermissionRepository : BaseRepository<Permission, Guid>, IPermissionRepository
    {
        public PermissionRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}

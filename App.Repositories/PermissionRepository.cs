using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using System;
using App.Models.DbContexts;

namespace App.Repositories
{
    public class PermissionRepository : BaseRepository<Permission, Guid>, IPermissionRepository
    {
        public PermissionRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
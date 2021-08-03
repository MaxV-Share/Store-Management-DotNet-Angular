using App.Infrastructures.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class PermissionRepository : BaseRepository<Permission, Guid>, IPermissionRepository
    {
        public PermissionRepository(ApplicationDbContext context, IUserService userService, ILogger<PermissionRepository> logger) : base(context, userService, logger)
        {
        }
    }
}

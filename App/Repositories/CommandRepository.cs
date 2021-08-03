using App.Infrastructures.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class CommandRepository : BaseRepository<Command,string>, IBaseRepository<Command,string>, ICommandRepository
    {
        public CommandRepository(ApplicationDbContext context, IUserService userService, ILogger<CommandRepository> logger) : base(context, userService, logger)
        {
        }
    }
}

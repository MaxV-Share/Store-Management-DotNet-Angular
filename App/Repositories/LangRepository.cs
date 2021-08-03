using App.Infrastructures.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class LangRepository : BaseRepository<Lang, string>, ILangRepository
    {
        public LangRepository(ApplicationDbContext context, IUserService userService, ILogger<LangRepository> logger) : base(context, userService, logger)
        {
        }
    }
}

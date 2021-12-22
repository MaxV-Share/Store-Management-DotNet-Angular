using App.Models.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using System;

namespace App.Repositories
{
    public class CommandInFunctionRepository : BaseRepository<CommandInFunction, Guid>, ICommandInFunctionRepository
    {
        public CommandInFunctionRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
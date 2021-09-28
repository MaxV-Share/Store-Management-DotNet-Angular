using App.Infrastructures.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class FunctionRepository : BaseRepository<Function, string>, IFunctionRepository
    {
        public FunctionRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) :  base(context, httpContextAccessor)
        {
        }
    }
}

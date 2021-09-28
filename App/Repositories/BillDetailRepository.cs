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
    public class BillDetailRepository : BaseRepository<BillDetail, int>, IBillDetailRepository
    {
        public BillDetailRepository(ApplicationDbContext context, IUserService userService, ILogger<BillDetailRepository> logger) : base(context, userService, logger)
        {

        }

    }
}

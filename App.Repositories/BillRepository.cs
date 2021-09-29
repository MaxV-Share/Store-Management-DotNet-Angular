using App.Models.Dbcontexts;
using App.Repositories.UnitOffWorks;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.Entities;
using App.Models.Entities.Identities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class BillRepository : BaseRepository<Bill, int>, IBillRepository
    {
        public BillRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : 
            base(context, httpContextAccessor)
        {
        }
    }
}

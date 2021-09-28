using App.Infrastructures.Dbcontexts;
using App.Models.DTOs;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class CategoryDetailRepository : BaseRepository<CategoryDetail, int>, ICategoryDetailRepository
    {
        public CategoryDetailRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) :  base(context, httpContextAccessor)
        {

        }
    }
}

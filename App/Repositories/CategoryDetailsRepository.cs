using App.Infrastructures.Dbcontexts;
using App.Models.DTOs;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class CategoryDetailsRepository : BaseRepository<CategoryDetail, int>, ICategoryDetailsRepository
    {
        public CategoryDetailsRepository(ApplicationDbContext context, IUserService userService) : base(context, userService)
        {

        }
    }
}

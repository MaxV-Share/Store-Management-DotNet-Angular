using App.DTOs;
using App.Infrastructures.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class DiscountRepository :  BaseRepository<Discount, int>,IDiscountRepository
    {
        public DiscountRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) :  base(context, httpContextAccessor)
        {
        }
    }
}

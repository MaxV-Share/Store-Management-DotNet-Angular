using App.Infrastructures.Dbcontexts;
using App.Models.DTOs;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class CategoriesRepository : BaseRepository<Category, int>, ICategoriesRepository
    {
        public CategoriesRepository(ApplicationDbContext context) : base(context)
        {
        }

        //public override async Task<Category> GetByIdNoTrackingAsync(int id)
        //{
        //    var entity = await Entities.Include(e => e.CategoryDetails).SingleOrDefaultAsync(x => x.Id.Equals(id) && x.Deleted == null);
        //    return entity;
        //}
    }
}

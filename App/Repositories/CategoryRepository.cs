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
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context, IUserService userService) : base(context, userService)
        {
        }

        public override Task<Category> GetByIdNoTrackingAsync(int id)
        {
            return GetNoTrackingEntities().Include(e => e.CategoryDetails).SingleOrDefaultAsync(e => e.Id == id);
        }
        public override Task<Category> GetByIdAsync(int id)
        {
            return Entities.Include(e => e.CategoryDetails.OrderBy(e => e.Lang.Order)).SingleOrDefaultAsync(e => e.Id == id);
        }
        public override async Task<Category> UpdateAsync(Category entity)
        {
            ValidateAndThrow(entity);

            var entry = _context.Entry(entity);
            entity.SetValueUpdate();
            _context.Update(entity);
            if (entry.State < EntityState.Added)
            {
                entry.State = EntityState.Modified;
            }
            return entity;
        }
        public override Task<Category> CreateAsync(Category entity)
        {
            return base.CreateAsync(entity);
        }
    }
}

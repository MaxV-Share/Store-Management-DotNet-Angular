using App.Infrastructures.Dbcontexts;
using App.Models.DTOs;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Category> PostAsync(CategoryCreateRequest request)
        {
            if (request == null)
                return null;
            var parent = await GetByIdAsync(request.ParentId.Value);
            Category obj = new Category()
            {
                Parent = parent
            };
            var result = await CreateAsync(obj);
            return result;
        }
    }
}

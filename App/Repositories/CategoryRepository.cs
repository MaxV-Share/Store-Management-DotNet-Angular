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
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<Category> PostAsync(CategoryRequest request)
        {
            return null;
            //if (request == null)
            //    return null;
            //Category obj = new Category()
            //{
            //    Name = request.Name
            //};
            //var result = await CreateAsync(obj);
            //return result;
        }
    }
}

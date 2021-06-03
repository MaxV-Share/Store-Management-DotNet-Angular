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
    public class CategoryDetailsRepository : BaseRepository<CategoryDetail, int>, ICategoryDetailsRepository
    {
        public CategoryDetailsRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IQueryable<CategoryDetail>> GetByCategoryId(int categoryId)
        {
            var result = GetQueryableTable().Include(e => e.Lang).Where(e => e.Category.Id == categoryId && e.Deleted == null);
            return result;
        }
    }
}

using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using App.Models.DbContexts;

namespace App.Repositories
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        //public override Task<Category> GetByIdAsync(int id,)
        //{
        //    return Entities.Include(e => e.CategoryDetails.OrderBy(e => e.Lang.Order)).SingleOrDefaultAsync(e => e.Id == id);
        //}
    }
}
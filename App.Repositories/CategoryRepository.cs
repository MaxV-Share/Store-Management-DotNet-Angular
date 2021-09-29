using App.Models.Dbcontexts;
using App.Models.DTOs;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) :  base(context, httpContextAccessor)
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
    }
}

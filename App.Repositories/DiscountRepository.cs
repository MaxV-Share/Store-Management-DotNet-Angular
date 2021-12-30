using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using App.Models.DbContexts;

namespace App.Repositories
{
    public class DiscountRepository : BaseRepository<Discount, int>, IDiscountRepository
    {
        public DiscountRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
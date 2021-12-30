using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using App.Models.DbContexts;

namespace App.Repositories
{
    public class BillRepository : BaseRepository<Bill, int>, IBillRepository
    {
        public BillRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) :
            base(context, httpContextAccessor)
        {
        }
    }
}
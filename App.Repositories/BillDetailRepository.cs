using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using App.Models.DbContexts;

namespace App.Repositories
{
    public class BillDetailRepository : BaseRepository<BillDetail, int>, IBillDetailRepository
    {
        public BillDetailRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}

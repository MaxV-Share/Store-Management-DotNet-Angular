using App.Models.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Microsoft.AspNetCore.Http;

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

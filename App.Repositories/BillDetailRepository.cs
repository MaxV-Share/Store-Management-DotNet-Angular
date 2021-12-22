using App.Models.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Microsoft.AspNetCore.Http;

namespace App.Repositories
{
    public class BillDetailRepository : BaseRepository<BillDetail, int>, IBillDetailRepository
    {
        public BillDetailRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {

        }
    }
}

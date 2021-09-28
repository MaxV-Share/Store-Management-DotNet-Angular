using App.Models.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class BillDetailRepository : BaseRepository<BillDetail, int>, IBillDetailRepository
    {
        public BillDetailRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}

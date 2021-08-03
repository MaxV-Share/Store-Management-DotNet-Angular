using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories.Interface
{
    public interface IBillRepository : IBaseRepository<Bill, int>
    {
        public Task<Bill> PostAsync(BillCreateRequest request);

    }
}

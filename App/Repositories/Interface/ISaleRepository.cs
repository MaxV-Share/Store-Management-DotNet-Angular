using App.DTOs;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories.Interface
{
    public interface ISaleRepository : IBaseRepository<Sale, int>
    {
        public Task<Sale> PostAsync(SaleRequest request);
    }
}

using App.DTOs;
using App.Infrastructures.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class SaleRepository :  BaseRepository<Sale>,ISaleRepository
    {
        public SaleRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<Sale> PostAsync(SaleRequest request)
        {
            if (request == null)
                return null;
            Sale obj = new Sale()
            {
                PercentDiscount = request.PercentDiscount,
                MaxDiscountPrice = request.MaxDiscountPrice,
                FromDate = request.FromDate,
                ToDate = request.ToDate

            };
            var result = await CreateAsync(obj);
            return result;
        }
    }
}

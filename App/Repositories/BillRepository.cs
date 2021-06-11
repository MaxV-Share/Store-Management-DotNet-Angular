using App.Infrastructures.Dbcontexts;
using App.Models.DTOs;
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
    public class BillRepository : BaseRepository<Bill, int>, IBillRepository
    {
        public BillRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Bill> PostAsync(BillCreateRequest request)
        {
            if (request == null)
                return null;
            Bill obj = new Bill()
            {
                Customer = request.Customer,
                UserPayment = request.UserPayment,
                TotalPrice = request.TotalPrice,
                DiscountPrice = request.DiscountPrice

            };
            var result = await CreateAsync(obj);
            return result;
        }
    }
}

using App.DTOs;
using App.Models.DTOs;
using App.Models.Entities;
using App.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services.Interface
{
    public interface IDiscountService : IBaseService<Discount, DiscountCR, DiscountVm, int>
    {
        public Task<int> PutAsync(int id, DiscountVm request);
        public Task<DiscountVm> PostAsync(DiscountCR request);
    }
}

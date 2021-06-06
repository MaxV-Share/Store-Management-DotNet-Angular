using App.DTOs;
using App.Models.DTOs;
using App.Models.Entities;
using App.Repositories;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class DiscountService : BaseService<Discount, DiscountCR, DiscountVm, int>, IDiscountService
    {
        public readonly IDiscountRepository _saleRepository;
        public DiscountService(IDiscountRepository saleRepository, IMapper mapper) : base(saleRepository, mapper)
        {
            _saleRepository = saleRepository;
        }
        public async Task<DiscountVm> PostAsync(DiscountCR request)
        {
            if (request == null)
                return null;
            Discount obj = new Discount()
            {
                PercentDiscount = request.PercentDiscount,
                MaxDiscountPrice = request.MaxDiscountPrice,
                FromDate = request.FromDate,
                ToDate = request.ToDate

            };
            var response = await _saleRepository.CreateAsync(obj);
            var result = _mapper.Map<DiscountVm>(response);
            return result;
        }
        public async Task<int> PutAsync(int id, DiscountVm request)
        {
            if (id != request.Id)
                return 0;

            var entity = await _saleRepository.GetByIdAsync(request.Id);
            if (entity == null)
                return 0;
            var dateTimeNow = DateTime.UtcNow;

            entity.PercentDiscount = request.PercentDiscount;
            entity.MaxDiscountPrice = request.MaxDiscountPrice;
            entity.FromDate = request.FromDate;
            entity.ToDate = request.ToDate;
            entity.UpdateAt = dateTimeNow;

            var result = await _repository.UpdateAsync(entity);
            return result;
        }
    }
}

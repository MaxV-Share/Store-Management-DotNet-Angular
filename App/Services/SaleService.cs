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
    public class SaleService : BaseService<Sale, SaleRequest, SaleNonRequest>, ISaleService
    {
        public readonly ISaleRepository _saleRepository;
        public SaleService(ISaleRepository saleRepository, IMapper mapper) : base(saleRepository, mapper)
        {
            _saleRepository = saleRepository;
        }
        public async Task<SaleNonRequest> PostAsync(SaleRequest request)
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
            var response = await _saleRepository.CreateAsync(obj);
            var result = _mapper.Map<SaleNonRequest>(response);
            return result;
        }
        public async Task<int> PutAsync(Guid uuid, SaleNonRequest request)
        {
            if (uuid != request.Uuid)
                return 0;

            var entity = await _saleRepository.GetByUuidTrackingAsync(request.Uuid);
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

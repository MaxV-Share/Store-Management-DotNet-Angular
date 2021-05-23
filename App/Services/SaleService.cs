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
    }
}

using App.Models.DTOs;
using App.Models.DTOs.Bills;
using App.Models.DTOs.CreateRequest;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using MaxV.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class BillDetailService : BaseService<BillDetail, BillDetailCreateRequest, BillDetailViewModel, int>, IBillDetailService
    {
        private readonly IBillRepository _billRepository;
        private readonly ILogger<BillDetailService> _logger;
        public BillDetailService(IBillDetailRepository repository, IMapper mapper, IBillRepository billRepository, ILogger<BillDetailService> logger) : base(repository, mapper)
        {
            _billRepository = billRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<BillDetailViewModel>> GetByBillIdAsync(int billId, string langId)
        {
            var entities = await _repository.GetNoTrackingEntitiesIdentityResolution()
                                        .Where(e => e.Deleted == null && e.Bill.Deleted == null && e.BillId == billId)
                                        .Select(e => new BillDetailViewModel()
                                        {
                                            BillId = billId,
                                            DiscountPrice = e.DiscountPrice,
                                            Id = e.Id,
                                            Price = e.Price,
                                            Product = new ProductInBillViewModel()
                                            {
                                                ProductId = e.Product.Id,
                                                Name = e.Product.ProductDetails.SingleOrDefault(e => e.LangId == langId && e.Deleted == null).Name,
                                                CategoryName = e.Product.Category.CategoryDetails.SingleOrDefault(e => e.LangId == langId && e.Deleted == null).Name,
                                                CategoryId = e.Product.CategoryId,
                                                ProductCode = e.Product.Code,
                                                ProductImageUrl = e.Product.ImageUrl,
                                                ProductUuid = e.Product.Uuid,
                                            },
                                            ProductId = e.Product.Id,
                                            Quantity = e.Quantity,
                                            Uuid = e.Uuid
                                        })
                                        .ToListAsync();

            return entities;
        }
    }
}

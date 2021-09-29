using App.Repositories.UnitOffWorks;
using App.Models.DTOs;
using App.Models.DTOs.Bills;
using App.Models.DTOs.CreateRequests;
using App.Models.Entities;
using App.Repositories.BaseRepository;
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
    public class BillDetailService : BaseService<BillDetail, BillDetailCreateRequest, BillDetailUpdateRequest, BillDetailViewModel, int>, IBillDetailService
    {
        public BillDetailService(IMapper mapper, IUnitOffWork unitOffWork, ILogger<BillDetailService> logger) : base(mapper, unitOffWork, logger)
        {
        }

        public async Task<IEnumerable<BillDetailViewModel>> GetByBillIdAsync(int billId, string langId)
        {
            var entities = await _unitOffWork.BillDetailRepository.GetNoTrackingEntities()
                                            .Include(e => e.Product.ProductDetails.Where(e => e.LangId == langId))
                                            .Include(e => e.Product.ProductDetails.Where(e => e.LangId == langId))
                                            .Include(e => e.Product.Category.CategoryDetails.Where(e => e.LangId == langId))
                                            .Where(e => e.BillId == billId)
                                            //.Select(e => new BillDetailViewModel()
                                            //{
                                            //    BillId = billId,
                                            //    DiscountPrice = e.DiscountPrice,
                                            //    Id = e.Id,
                                            //    Price = e.Price,
                                            //    Product = new ProductInBillViewModel()
                                            //    {
                                            //        Id = e.Product.Id,
                                            //        Name = e.Product.ProductDetails.SingleOrDefault(e => e.LangId == langId).Name,
                                            //        CategoryName = e.Product.Category.CategoryDetails.SingleOrDefault(e => e.LangId == langId).Name,
                                            //        CategoryId = e.Product.CategoryId,
                                            //        Code = e.Product.Code,
                                            //        ImageUrl = e.Product.ImageUrl,
                                            //        Uuid = e.Product.Uuid,
                                            //    },
                                            //    ProductId = e.Product.Id,
                                            //    Quantity = e.Quantity,
                                            //    Uuid = e.Uuid
                                            //})
                                            .ToListAsync();
            var result = _mapper.Map<List<BillDetailViewModel>>(entities);

            return result;
        }
    }
}

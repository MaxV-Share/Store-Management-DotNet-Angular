using App.Models.DTOs.Bills;
using App.Models.DTOs.CreateRequests;
using App.Models.Entities;
using App.Repositories.UnitOffWorks;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.DTOs.BillDetails;

namespace App.Services
{
    public class BillDetailService : BaseService<BillDetail, BillDetailCreateRequest, BillDetailUpdateRequest, BillDetailViewModel, int>, IBillDetailService
    {
        public BillDetailService(IMapper mapper, IUnitOffWork unitOffWork, ILogger<BillDetailService> logger) : base(mapper, unitOffWork, logger)
        {
        }
        public async Task<IEnumerable<BillDetailViewModel>> GetByBillIdAsync(int id, string langId)
        {
            var entities = await _unitOffWork.Repository<BillDetail, int>().GetNoTrackingEntities()
                                            .Include(e => e.Product.ProductDetails.Where(e => e.LangId == langId))
                                            .Include(e => e.Product.ProductDetails.Where(e => e.LangId == langId))
                                            .Include(e => e.Product.Category.CategoryDetails.Where(e => e.LangId == langId))
                                            .Where(e => e.BillId == id)
                                            .ToListAsync();
            var result = _mapper.Map<List<BillDetailViewModel>>(entities);

            return result;
        }
    }
}

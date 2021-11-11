using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Repositories.UnitOffWorks;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace App.Services
{
    public class DiscountService : BaseService<Discount, DiscountCreateRequest, DiscountUpdateRequest, DiscountViewModel, int>, IDiscountService
    {
        public DiscountService(IMapper mapper, IUnitOffWork unitOffWork, ILogger<DiscountService> logger) : base(mapper, unitOffWork, logger)
        {
        }
    }
}

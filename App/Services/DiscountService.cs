using App.DTOs;
using App.Infrastructures.UnitOffWorks;
using App.Models.DTOs;
using App.Models.DTOs.UpdateRquests;
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
    public class DiscountService : BaseService<Discount, DiscountCreateRequest, DiscountUpdateRequest, DiscountViewModel, int>, IDiscountService
    {
        public DiscountService(IDiscountRepository discountRepository, IMapper mapper, IUnitOffWork unitOffWork) : base(discountRepository, mapper, unitOffWork)
        {
        }
    }
}

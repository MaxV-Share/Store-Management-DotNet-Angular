using App.Infrastructures.Dbcontexts;
using App.Infrastructures.UnitOffWorks;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.Entities;
using App.Models.Entities.Identities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class BillRepository : BaseRepository<Bill, int>, IBillRepository
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly UserManager<User> _userManager;
        public BillRepository(ApplicationDbContext context, ICustomerRepository customerRepository, UserManager<User> userManager, IUserService userService, ILogger<BillRepository> logger) : base(context, userService, logger)
        {
            _customerRepository = customerRepository;
            _userManager = userManager;
        }

        public async Task<Bill> PostAsync(BillCreateRequest request)
        {
            if (request == null)
                return null;
            var customer = _customerRepository.GetByPhoneNumberAsync(request.CustomerPhoneNumber);
            var userPayment = _userManager.FindByIdAsync(request.UserPaymentId);
            var objModel = new Bill()
            {
                Customer = await customer,
                UserPayment = await userPayment,
                TotalPrice = request.TotalPrice,
                DiscountPrice = request.DiscountPrice
            };
            var result = await CreateAsync(objModel);
            return result;
        }
    }
}

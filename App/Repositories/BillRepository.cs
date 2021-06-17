using App.Infrastructures.Dbcontexts;
using App.Models.DTOs;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class BillRepository : BaseRepository<Bill, int>, IBillRepository
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        public BillRepository(ApplicationDbContext context, ICustomerRepository customerRepository, IUserRepository userRepository) : base(context)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }

        public async Task<Bill> PostAsync(BillCreateRequest request)
        {
            if (request == null)
                return null;
            var customer = _customerRepository.GetByPhoneNumberAsync(request.CustomerPhoneNumber);
            var userPayment = _userRepository.GetByIdAsync(request.UserPaymentId);
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

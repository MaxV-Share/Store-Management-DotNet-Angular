using App.DTOs;
using App.Infrastructures.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<Customer> PostAsync(CustomerCreateRequest request)
        {
            if (request == null)
                return null;
            Customer obj = new Customer()
            {
                PhoneNumber = request.PhoneNumber,
                FullName = request.FullName,
                Birthday = request.Birthday,
            };
            //var result = await CreateAsync(obj);
            //return result;
            return null;
        }
    }
}

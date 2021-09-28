using App.DTOs;
using App.Infrastructures.Dbcontexts;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) :  base(context, httpContextAccessor)
        {
        }

        public Task<Customer> GetByPhoneNumberAsync(string phoneNumber)
        {
            return Entities.SingleOrDefaultAsync(e => e.PhoneNumber.Equals(phoneNumber));
        }
    }
}

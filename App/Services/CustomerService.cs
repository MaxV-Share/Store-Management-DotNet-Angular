using App.DTOs;
using App.Infrastructures.UnitOffWorks;
using App.Models.DTOs;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Services
{
    public class CustomerService : BaseService<Customer, CustomerCreateRequest, CustomerUpdateRequest, CustomerViewModel, int>, ICustomerService
    {

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper, IUnitOffWork unitOffWork, ILogger<CustomerService> logger) : base(customerRepository, mapper, unitOffWork, logger)
        {
        }
    }
}

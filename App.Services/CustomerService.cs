using App.DTOs;
using App.Models.DTOs;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Repositories.UnitOffWorks;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace App.Services
{
    public class CustomerService : BaseService<Customer, CustomerCreateRequest, CustomerUpdateRequest, CustomerViewModel, int>, ICustomerService
    {

        public CustomerService(IMapper mapper, IUnitOffWork unitOffWork, ILogger<CustomerService> logger) : base(mapper, unitOffWork, logger)
        {
        }

    }
}

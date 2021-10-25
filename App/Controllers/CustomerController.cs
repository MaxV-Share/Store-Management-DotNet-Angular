using App.Controllers.Base;
using App.DTOs;
using App.Models.DTOs;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Interface;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class CustomerController : CRUDContoller<Customer, CustomerCreateRequest, CustomerUpdateRequest, CustomerViewModel, int>
    {
        public readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger) : base(logger, customerService)
        {
            _customerService = customerService;
        }
    }
}

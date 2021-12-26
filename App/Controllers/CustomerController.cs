using App.Controllers.Base;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Interface;
using MaxV.Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class CustomerController : CrudController<Customer, CustomerCreateRequest, CustomerUpdateRequest, CustomerViewModel, int>
    {
        public readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger) : base(logger, customerService)
        {
            _customerService = customerService;
        }

        public override async Task<ActionResult> GetPaging(FilterBodyRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}

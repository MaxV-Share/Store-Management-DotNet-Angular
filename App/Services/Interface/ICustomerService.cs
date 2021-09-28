using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DTOs;
using App.Models.DTOs;
using App.Models.Entities;
using App.Services.Base;

namespace App.Services.Interface
{
    public interface ICustomerService : IBaseService<Customer, CustomerCreateRequest, CustomerViewModel, int>
    {
       public Task<CustomerViewModel> PostAsync(CustomerCreateRequest request);
       public Task<int> PutAsync(Guid uuid, CustomerViewModel request);
    }
}

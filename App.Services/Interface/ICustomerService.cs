using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DTOs;
using App.Models.DTOs;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Base;

namespace App.Services.Interface
{
    public interface ICustomerService : IBaseService<Customer, CustomerCreateRequest, CustomerUpdateRequest, CustomerViewModel, int>
    {
    }
}

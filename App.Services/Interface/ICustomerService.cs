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

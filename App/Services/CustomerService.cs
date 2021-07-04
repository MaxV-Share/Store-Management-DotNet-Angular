using App.DTOs;
using App.Models.DTOs;
using App.Models.Entities;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace App.Services
{
    public class CustomerService : BaseService<Customer, CustomerCreateRequest, CustomerViewModel, int>, ICustomerService
    {
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper) : base(customerRepository, mapper)
        {
        }
        public async Task<CustomerViewModel> PostAsync(CustomerCreateRequest request)
        {
            if (request == null)
                return null;
            Customer obj = new Customer()
            {     
                PhoneNumber = request.PhoneNumber,
                FullName = request.FullName,
                Birthday = request.Birthday,
            };
            var response = await _repository.CreateAsync(obj);
            var result = _mapper.Map<CustomerViewModel>(response);
            return result;
        }
        public async Task<int> PutAsync(Guid uuid, CustomerViewModel request)
        {
            if (uuid != request.Uuid)
                return 0;

            var entity = await _repository.GetByUuidAsync(request.Uuid.Value);
            
            if (entity == null)
                return 0;
            var dateTimeNow = DateTime.UtcNow;
            entity.FullName = request.FullName;
            entity.PhoneNumber = request.PhoneNumber;
            entity.Birthday = request.Birthday;
            entity.UpdateAt = dateTimeNow;

            var result = await _repository.UpdateAsync(entity);
            return result;
        }

    }
}

﻿using App.DTOs;
using App.Models.Entities;
using App.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Repositories.Interface
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        public Task<Customer> PostAsync(CustomerRequest request);
        public Task<Customer> GetByUuidAsync(Guid uuid);
    }
}
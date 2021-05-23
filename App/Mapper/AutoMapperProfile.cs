using App.Models.Entities;
using App.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DTOs;
using App.Models.DTOs;

namespace App.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserRequest>();
            CreateMap<User, UserNonRequest>();
            CreateMap<Customer, CustomerRequest>();
            CreateMap<Customer, CustomerNonRequest>();
            CreateMap<Sale, SaleRequest>();
            CreateMap<Sale, SaleNonRequest>();
            CreateMap<Category, CategoryRequest>();
            CreateMap<Category, CategoryNonRequest>();
        }

    }
}


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
            CreateMap<User, UserCreateRequest>();
            CreateMap<User, UserViewModel>();
            CreateMap<Customer, CustomerCreateRequest>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<Discount, DiscountCreateRequest>();
            CreateMap<Discount, DiscountViewModel>();
            CreateMap<Category, CategoryCreateRequest>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryDetail, CategoryDetailCreateRequest>();
            CreateMap<CategoryDetail, CategoryDetailViewModel>();
        }

    }
}

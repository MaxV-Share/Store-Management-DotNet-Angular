
using App.Models.Entities;
using App.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DTOs;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequest;

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
            CreateMap<Product, ProductCreateRequest>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductDetail, ProductDetailCreateRequest>();
            CreateMap<ProductDetail, ProductDetailViewModel>();
            CreateMap<Bill, BillCreateRequest>();
            CreateMap<Bill, BillViewModel>();
        }

    }
}

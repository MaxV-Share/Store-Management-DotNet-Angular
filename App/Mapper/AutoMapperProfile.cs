
using App.Models.Entities;
using App.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.DTOs;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.Bills;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities.Identities;
using App.Models.DTOs.UpdateRquests;

namespace App.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserCreateRequest>();
            CreateMap<UserCreateRequest, User>();
            CreateMap<User, UserUpdateRequest>();
            CreateMap<UserUpdateRequest, User>();

            CreateMap<Customer, CustomerCreateRequest>();
            CreateMap<CustomerCreateRequest, Customer>();
            CreateMap<Customer, CustomerUpdateRequest>();
            CreateMap<CustomerUpdateRequest, Customer>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();

            CreateMap<Discount, DiscountCreateRequest>();
            CreateMap<DiscountCreateRequest, Discount>();
            CreateMap<Discount, DiscountViewModel>();
            CreateMap<DiscountViewModel, Discount>();

            CreateMap<Category, CategoryCreateRequest>();
            CreateMap<CategoryCreateRequest, Category>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<Category, CategoryUpdateRequest>();
            CreateMap<CategoryUpdateRequest, Category>();

            CreateMap<CategoryDetail, CategoryDetailCreateRequest>();
            CreateMap<CategoryDetailCreateRequest, CategoryDetail>();
            CreateMap<CategoryDetail, CategoryDetailViewModel>();
            CreateMap<CategoryDetailViewModel, CategoryDetail>();

            CreateMap<Product, ProductCreateRequest>();
            CreateMap<ProductCreateRequest, Product>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, ProductInBillViewModel>();
            CreateMap<ProductInBillViewModel, Product>();

            CreateMap<ProductDetail, ProductDetailCreateRequest>();
            CreateMap<ProductDetailCreateRequest, ProductDetail>();
            CreateMap<ProductDetail, ProductDetailViewModel>();
            CreateMap<ProductDetailViewModel, ProductDetail>();

            CreateMap<Bill, BillCreateRequest>();
            CreateMap<BillCreateRequest, Bill>();
            CreateMap<Bill, BillViewModel>();
            CreateMap<BillViewModel, Bill>();

            CreateMap<BillDetail, BillDetailCreateRequest>();
            CreateMap<BillDetailCreateRequest, BillDetail>();
            CreateMap<BillDetail, BillDetailViewModel>();
            CreateMap<BillDetailViewModel, BillDetail>();
        }

    }
}

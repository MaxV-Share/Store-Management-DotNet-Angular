
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

namespace App.Infrastructures.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Bill, BillCreateRequest>().ReverseMap();
            CreateMap<Bill, BillViewModel>().ReverseMap();

            CreateMap<BillDetail, BillDetailCreateRequest>().ReverseMap();
            CreateMap<BillDetail, BillDetailViewModel>().ReverseMap();

            CreateMap<Category, CategoryCreateRequest>().ReverseMap();
            CreateMap<Category, CategoryUpdateRequest>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();

            CreateMap<CategoryDetail, CategoryDetailCreateRequest>().ReverseMap(); 
            CreateMap<CategoryDetail, CategoryDetailUpdateRequest>().ReverseMap();
            CreateMap<CategoryDetail, CategoryDetailViewModel>().ReverseMap();

            CreateMap<CommandInFunction, CommandInFunctionCreateRequest>().ReverseMap();
            CreateMap<CommandInFunction, CommandInFunctionUpdateRequest>().ReverseMap();
            CreateMap<CommandInFunction, CommandInFunctionViewModel>().ReverseMap();

            CreateMap<Command, CommandCreateRequest>().ReverseMap();
            CreateMap<Command, CommandUpdateRequest>().ReverseMap();
            CreateMap<Command, CommandViewModel>().ReverseMap();

            CreateMap<Customer, CustomerCreateRequest>().ReverseMap();
            CreateMap<Customer, CustomerUpdateRequest>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();

            CreateMap<Discount, DiscountCreateRequest>().ReverseMap();
            CreateMap<Discount, DiscountUpdateRequest>().ReverseMap();
            CreateMap<Discount, DiscountViewModel>().ReverseMap();

            CreateMap<Function, FunctionCreateRequest>().ReverseMap();
            CreateMap<Function, FunctionUpdateRequest>().ReverseMap();
            CreateMap<Function, FunctionViewModel>().ReverseMap();
            //CreateMap<FunctionViewModel, TreeFunctionViewModel>()
            //    .ForMember(dest => dest.Data, opt => opt.MapFrom(source => source))
            //    .ForMember(dest => dest.Children, opt => opt.MapFrom(source => source));

            CreateMap<Permission, PermissionCreateRequest>().ReverseMap();
            CreateMap<Permission, PermissionUpdateRequest>().ReverseMap();
            CreateMap<Permission, PermissionViewModel>().ReverseMap();

            CreateMap<Product, ProductCreateRequest>().ReverseMap();
            CreateMap<Product, ProductUpdateRequest>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, ProductInBillViewModel>()
                .ForMember(dest => dest.Detail, option => option.MapFrom(source => source.ProductDetails.SingleOrDefault())).ReverseMap();

            CreateMap<ProductDetail, ProductDetailCreateRequest>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailUpdateRequest>().ReverseMap();
            CreateMap<ProductDetail, ProductDetailViewModel>().ReverseMap();

            CreateMap<User, UserCreateRequest>().ReverseMap();
            CreateMap<User, UserUpdateRequest>().ReverseMap();

            CreateMap<Role, RoleCreateRequest>().ReverseMap();
            CreateMap<Role, RoleUpdateRequest>().ReverseMap();
            CreateMap<Role, RoleViewModel>().ReverseMap();

        }

    }
}

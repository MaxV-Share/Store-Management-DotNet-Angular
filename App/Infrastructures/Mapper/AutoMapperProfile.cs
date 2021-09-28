
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

namespace App.Infrastructures.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Bill, BillCreateRequest>();
            CreateMap<BillCreateRequest, Bill>();
            CreateMap<Bill, BillViewModel>();
            CreateMap<BillViewModel, Bill>();

            CreateMap<BillDetail, BillDetailCreateRequest>();
            CreateMap<BillDetailCreateRequest, BillDetail>();
            CreateMap<BillDetail, BillDetailViewModel>();
            CreateMap<BillDetailViewModel, BillDetail>();

            CreateMap<Category, CategoryCreateRequest>();
            CreateMap<CategoryCreateRequest, Category>();
            CreateMap<Category, CategoryUpdateRequest>();
            CreateMap<CategoryUpdateRequest, Category>();
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();

            CreateMap<CategoryDetail, CategoryDetailCreateRequest>();
            CreateMap<CategoryDetailCreateRequest, CategoryDetail>();
            CreateMap<CategoryDetail, CategoryDetailUpdateRequest>();
            CreateMap<CategoryDetailUpdateRequest, CategoryDetail>();
            CreateMap<CategoryDetail, CategoryDetailViewModel>();
            CreateMap<CategoryDetailViewModel, CategoryDetail>();

            CreateMap<CommandInFunction, CommandInFunctionCreateRequest>();
            CreateMap<CommandInFunctionCreateRequest, CommandInFunction>();
            CreateMap<CommandInFunction, CommandInFunctionUpdateRequest>();
            CreateMap<CommandInFunctionUpdateRequest, CommandInFunction>();
            CreateMap<CommandInFunction, CommandInFunctionViewModel>();
            CreateMap<CommandInFunctionViewModel, CommandInFunction>();

            CreateMap<Command, CommandCreateRequest>();
            CreateMap<CommandCreateRequest, Command>();
            CreateMap<Command, CommandUpdateRequest>();
            CreateMap<CommandUpdateRequest, Command>();
            CreateMap<Command, CommandViewModel>();
            CreateMap<CommandViewModel, Command>();

            CreateMap<Customer, CustomerCreateRequest>();
            CreateMap<CustomerCreateRequest, Customer>();
            CreateMap<Customer, CustomerUpdateRequest>();
            CreateMap<CustomerUpdateRequest, Customer>();
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();

            CreateMap<Discount, DiscountCreateRequest>();
            CreateMap<DiscountCreateRequest, Discount>();
            CreateMap<Discount, DiscountUpdateRequest>();
            CreateMap<DiscountUpdateRequest, Discount>();
            CreateMap<Discount, DiscountViewModel>();
            CreateMap<DiscountViewModel, Discount>();

            CreateMap<Function, FunctionCreateRequest>();
            CreateMap<FunctionCreateRequest, Function>();
            CreateMap<Function, FunctionUpdateRequest>();
            CreateMap<FunctionUpdateRequest, Function>();
            CreateMap<Function, FunctionViewModel>();
            CreateMap<FunctionViewModel, Function>();
            //CreateMap<FunctionViewModel, TreeFunctionViewModel>()
            //    .ForMember(dest => dest.Data, opt => opt.MapFrom(source => source))
            //    .ForMember(dest => dest.Children, opt => opt.MapFrom(source => source));

            CreateMap<User, UserCreateRequest>();
            CreateMap<UserCreateRequest, User>();
            CreateMap<User, UserUpdateRequest>();
            CreateMap<UserUpdateRequest, User>();

            CreateMap<Permission, PermissionCreateRequest>();
            CreateMap<PermissionCreateRequest, Permission>();
            CreateMap<Permission, PermissionUpdateRequest>();
            CreateMap<PermissionUpdateRequest, Permission>();
            CreateMap<Permission, PermissionViewModel>();
            CreateMap<PermissionViewModel, Permission>();

            CreateMap<Product, ProductCreateRequest>();
            CreateMap<ProductCreateRequest, Product>();
            CreateMap<Product, ProductUpdateRequest>();
            CreateMap<ProductUpdateRequest, Product>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<Product, ProductInBillViewModel>()
                .ForMember(dest => dest.Detail, option => option.MapFrom(source => source.ProductDetails.SingleOrDefault()));

            CreateMap<ProductDetail, ProductDetailCreateRequest>();
            CreateMap<ProductDetailCreateRequest, ProductDetail>();
            CreateMap<ProductDetail, ProductDetailUpdateRequest>();
            CreateMap<ProductDetailUpdateRequest, ProductDetail>();
            CreateMap<ProductDetail, ProductDetailViewModel>();
            CreateMap<ProductDetailViewModel, ProductDetail>();

        }

    }
}

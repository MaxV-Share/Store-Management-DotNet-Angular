using App.Infrastructures.Mapper;
using App.Models.Dbcontexts;
using App.Models.Entities;
using App.Models.Entities.Identities;
using App.Repositories;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Repositories.UnitOffWorks;
using App.Services;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.Infrastructures.Startup.ServicesExtensions
{
    public static class InjectionServiceExtension
    {
        public static void AddInjectedServices(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            //DI
            services.AddSingleton(mapper);
            services.AddTransient<DBInitializer>();
            services.AddScoped<IUnitOffWork, UnitOffWork>();

            services.AddScoped<UserManager<User>>();

            //services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
            services.AddScoped<IBaseRepository<BillDetail, int>, BillDetailRepository>();
            services.AddScoped<IBaseRepository<Bill, int>, BillRepository>();
            services.AddScoped<IBaseRepository<Category, int>, CategoryRepository>();
            services.AddScoped<IBaseRepository<CategoryDetail, int>, CategoryDetailRepository>();
            services.AddScoped<IBaseRepository<Command, string>, CommandRepository>();
            services.AddScoped<IBaseRepository<CommandInFunction, Guid>, CommandInFunctionRepository>();
            services.AddScoped<IBaseRepository<Customer, int>, CustomerRepository>();
            services.AddScoped<IBaseRepository<Discount, int>, DiscountRepository>();
            services.AddScoped<IBaseRepository<Function, string>, FunctionRepository>();
            services.AddScoped<IBaseRepository<Lang, string>, LangRepository>();
            services.AddScoped<IBaseRepository<Product, int>, ProductRepository>();
            services.AddScoped<IBaseRepository<ProductDetail, int>, ProductDetailRepository>();

            services.AddScoped<IBillDetailRepository, BillDetailRepository>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryDetailRepository, CategoryDetailRepository>();
            services.AddScoped<ICommandRepository, CommandRepository>();
            services.AddScoped<ICommandInFunctionRepository, CommandInFunctionRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IFunctionRepository, FunctionRepository>();
            services.AddScoped<ILangRepository, LangRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductDetailRepository, ProductDetailRepository>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IBillDetailService, BillDetailService>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<ICommandInFunctionService, CommandInFunctionService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IStorageService, FileStorageService>();
            services.AddScoped<IFunctionService, FunctionService>();
            services.AddScoped<ILangService, LangService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRevenueService, RevenueService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
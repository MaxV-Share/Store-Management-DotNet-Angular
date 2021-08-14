using App.Models.Entities;
using App.Infrastructures.Dbcontexts;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using App.Repositories;
using App.Infrastructures.UnitOffWorks;
using App.Models.Entities.Identities;
using App.Infrastructures.Mapper;

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
            services.AddScoped<DBInitializer>();
            services.AddTransient<IUnitOffWork, UnitOffWork>();

            services.AddScoped<UserManager<User>>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IBillDetailRepository, BillDetailRepository>();
            services.AddScoped<IBillDetailService, BillDetailService>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryDetailsRepository, CategoryDetailsRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommandRepository, CommandRepository>();
            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<ICommandInFunctionRepository, CommandInFunctionRepository>();
            services.AddScoped<ICommandInFunctionService, CommandInFunctionService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IStorageService, FileStorageService>();
            services.AddScoped<IFunctionRepository, FunctionRepository>();
            services.AddScoped<IFunctionService, FunctionService>();
            services.AddScoped<ILangRepository, LangRepository>();
            services.AddScoped<ILangService, LangService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductDetailRepository, ProductDetailRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IRevenueService, RevenueService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
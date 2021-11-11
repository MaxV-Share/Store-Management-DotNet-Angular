using App.Models.DTOs.Bills;
using App.Models.DTOs.CreateRequests;
using App.Models.Entities;
using App.Repositories;
using App.Repositories.Interface;
using App.Services.Base;
using App.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace App.Services.Extenstions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
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

using App.Common.Extensions;
using App.Common.Interceptors;
using App.Models.DTOs.Bills;
using App.Models.DTOs.CreateRequests;
using App.Models.Entities;
using App.Repositories;
using App.Repositories.Extenstions;
using App.Services.Base;
using App.Services.Interface;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;

namespace App.Services.Extenstions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IProxyGenerator, ProxyGenerator>();
            services.AddScoped<IAsyncInterceptor, MonitoringInterceptor>();
            services.AddProxiedScoped<IAuthenticationService, AuthenticationService>();
            services.AddProxiedScoped<IBillDetailService, BillDetailService>();
            services.AddProxiedScoped<IBillService, BillService>();
            services.AddProxiedScoped<ICategoryService, CategoryService>();
            services.AddProxiedScoped<ICommandService, CommandService>();
            services.AddProxiedScoped<ICommandInFunctionService, CommandInFunctionService>();
            services.AddProxiedScoped<ICustomerService, CustomerService>();
            services.AddProxiedScoped<IDiscountService, DiscountService>();
            services.AddProxiedScoped<IStorageService, FileStorageService>();
            services.AddProxiedScoped<IFunctionService, FunctionService>();
            services.AddProxiedScoped<ILangService, LangService>();
            services.AddProxiedScoped<IProductService, ProductService>();
            services.AddProxiedScoped<IRevenueService, RevenueService>();
            services.AddProxiedScoped<IRoleService, RoleService>();
            services.AddProxiedScoped<IUserService, UserService>();
        }
    }
}

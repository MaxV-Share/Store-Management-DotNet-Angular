using App.Models.Entities;
using App.Infrastructures.Dbcontexts;
using App.Mapper;
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
            services.AddScoped<IUnitOffWork, UnitOffWork>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<UserManager<User>, UserManager<User>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IDiscountRepository, DiscountRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ILangRepository, LangRepository>();
            services.AddScoped<ILangService, LangService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryDetailsRepository, CategoryDetailsRepository>();
            services.AddScoped<IProductDetailRepository, ProductDetailRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IBillService, BillService>();
            services.AddScoped<IBillDetailRepository, BillDetailRepository>();
            services.AddScoped<IBillDetailService, BillDetailService>();
            services.AddScoped<IStorageService, FileStorageService>();
            services.AddScoped<IRevenueService, RevenueService>();
        }
    }
}
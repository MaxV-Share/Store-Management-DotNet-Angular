using App.Models.Entities;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.Repositories.Extenstions
{
    public static class RepositoryExtenstions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
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
        }
    }
}
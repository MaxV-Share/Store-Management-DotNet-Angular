﻿using App.Data.Entities;
using App.Infrastructures.Dbcontexts;
using App.Mapper;
using App.Repositories.BaseRepository;
using App.Repositories.Interface;
using App.Services;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<UserManager<User>, UserManager<User>>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

        }
    }
}
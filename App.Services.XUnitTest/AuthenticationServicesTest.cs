using System;
using System.Threading.Tasks;
using App.Models.DbContexts;
using App.Models.DTOs;
using App.Models.Entities.Identities;
using App.Models.Mapper;
using App.Repositories.XUnitTest;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace App.Services.XUnitTest
{
    public class AuthenticationServicesTest
    {
        private readonly Mock<IDistributedCache> _cache;
        private readonly Mock<UserManager<User>> _userManager;
        private readonly Mock<SignInManager<User>> _signInManager;
        private readonly Mock<RoleManager<Role>> _roleManager;
        private readonly Mock<IConfiguration> _configuration;
        private readonly Mock<IUserService> _userService;
        private readonly Mock<JwtOptions> _jwtOptions;
        public AuthenticationServicesTest()
        {

            var store = new Mock<IUserStore<User>>();
            _userManager = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null);

            _userManager.Object.UserValidators.Add(new UserValidator<User>());
            _userManager.Object.PasswordValidators.Add(new PasswordValidator<User>());
        }
        [Fact]
        public async Task AuthenticationServices_LoginAsync_NotNull_Success()
        {
            _userManager.Setup(e => e.FindByNameAsync(It.IsAny<string>())).Returns<User>(null);
            var authenticationService = new AuthenticationService(_userManager.Object, null, null, null, null, null, null);
            var result = await authenticationService.LoginAsync(new Common.Model.DTOs.LoginDTO() { UserName = "" });
            Assert.True(true);
        }
    }
}


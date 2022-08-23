using System;
using System.Threading.Tasks;
using App.Common.Model.DTOs;
using App.Models.DbContexts;
using App.Models.DTOs;
using App.Models.Entities.Identities;
using App.Models.Mapper;
using App.Repositories.XUnitTest;
using App.Services.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
        public async Task AuthenticationServices_LoginAsync_UserNull_Status404NotFound()
        {
            _userManager.Setup(e => e.FindByNameAsync(It.IsAny<string>())).ReturnsAsync((string user) =>
            {
                return null;
            });
            var authenticationService = new AuthenticationService(_userManager.Object, null, null, null, null, null, null);
            var result = await authenticationService.LoginAsync(new LoginDTO() { UserName = "" });
            Assert.Equal(result.StatusCode, StatusCodes.Status404NotFound);
        }
        [Fact]
        public async Task AuthenticationServices_LoginAsync_UserNotNull_Status404NotFound()
        {
            _userManager.Setup(e => e.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(new User());
            _userManager.Setup(e => e.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(false);
            var authenticationService = new AuthenticationService(_userManager.Object, null, null, null, null, null, null);
            var result = await authenticationService.LoginAsync(new LoginDTO() { UserName = "" });
            Assert.Equal(result.StatusCode, StatusCodes.Status404NotFound);
        }
        [Fact]
        public async Task AuthenticationServices_LoginAsync_UserNameNull_ThrowException()
        {
            _userManager.Setup(e => e.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(new User());
            _userManager.Setup(e => e.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(true);
            var authenticationService = new AuthenticationService(_userManager.Object, null, null, null, null, null, null);
            await Assert.ThrowsAsync<ArgumentNullException>(() => authenticationService.LoginAsync(new LoginDTO() { UserName = "" }));
        }
        [Fact]
        public async Task AuthenticationServices_LoginAsync_UserRolesNull_ThrowException()
        {
            _userManager.Setup(e => e.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(new User());
            _userManager.Setup(e => e.CheckPasswordAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(true);
            _userManager.Setup(e => e.GetRolesAsync(It.IsAny<User>())).ReturnsAsync((User e) =>
            {
                return null;
            });
            var authenticationService = new AuthenticationService(_userManager.Object, null, null, null, null, null, null);
            await Assert.ThrowsAsync<ArgumentNullException>(() => authenticationService.LoginAsync(new LoginDTO() { UserName = "" }));
        }
    }
}


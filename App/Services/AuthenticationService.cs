using App.Models.Entities;
using App.DTO;
using App.Services.Interface;
using MaxV.Base.DTOs;
using MaxV.Helper.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace App.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IDistributedCache _cache;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IOptions<JwtOptions> _jwtOptions;
        public AuthenticationService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, IConfiguration configuration, IDistributedCache cache, IOptions<JwtOptions> jwtOptions)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _cache = cache;
            _jwtOptions = jwtOptions;
        }
        public async Task<Response<string>> Login(LoginDTO request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return new Response<string>(StatusCodes.Status404NotFound, "UserName or Password is incorrect");

            IEnumerable<string> userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,
                          user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

            userRoles.ToList().ForEach(e =>
            {
                authClaims.Add(new Claim(ClaimTypes.Role, e));
            });

            await _signInManager.SignInAsync(user, true);

            var authSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: authClaims,
                expires: DateTime.Now.AddHours(5),
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256)
                );
            return new Response<string>(StatusCodes.Status200OK,"Success", new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task Logout(string request)
        {
            await _cache.SetStringAsync($"tokens:{request}:deactivated",
               " ", new DistributedCacheEntryOptions
               {
                   AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
               });
            await _signInManager.SignOutAsync();
        }

        public async Task<Response<bool>> Register(RegisterDTO request)
        {
            var response = new Response<bool>();
            if (request.Password != request.ConfirmPassword)
            {
                return new Response<bool>(StatusCodes.Status400BadRequest, "Passwords didn't match.", false);
            }

            using (var transaction = new CommittableTransaction(new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                try
                {
                    var userExist = await _userManager.FindByNameAsync(request.UserName);
                    if (userExist != null)
                    {
                        return new Response<bool>(StatusCodes.Status400BadRequest, "User already exists.", false);
                    }
                    var user = new User()
                    {
                        UserName = request.UserName,
                        Email = request.Email,
                        SecurityStamp = Guid.NewGuid().ToString(),
                    };

                    var result = await _userManager.CreateAsync(user, request.Password);

                    if (!await _roleManager.RoleExistsAsync(UserRole.Admin))
                        await _roleManager.CreateAsync(new IdentityRole(UserRole.Admin));

                    await _userManager.AddToRolesAsync(user, request.Roles);

                    transaction.Commit();

                    if (!result.Succeeded)
                    {
                        return new Response<bool>(StatusCodes.Status400BadRequest, "User already exists.",false);
                    }

                    response.StatusCode = StatusCodes.Status200OK;
                    response.Body = true;
                    return response;
                }
                catch (Exception ex)
                {
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.Body = false;
                    response.Message = ex.StackTrace;
                    return response;
                }
            }
        }
        public async Task<string> CheckToken(string authorization)
        {
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                // we have a valid AuthenticationHeaderValue that has the following details:

                var scheme = headerValue.Scheme;
                var tokenHeader = headerValue.Parameter;

                var validationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.Value.Secret)),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(tokenHeader, validationParameters, out var securityToken);
                var jwtSecurityToken = (JwtSecurityToken)securityToken;
                var userName = jwtSecurityToken.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Name).Value;
                return userName;
                // scheme will be "Bearer"
                // parameter will be the token itself.
            }
            return null;
        }
    }
}